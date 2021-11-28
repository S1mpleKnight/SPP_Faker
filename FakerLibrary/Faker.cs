using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    public class Faker : IFaker
    {
        private Generator generator;

        public Faker()
        {
            generator = new Generator();
        }

        private ConstructorInfo getConstructorWithMaxParameters(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            ConstructorInfo maxConstructor = null;
            if (constructors.Length > 0)
            {
                int maxLength = 0;
                foreach (ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length > maxLength)
                    {
                        maxLength = constructor.GetParameters().Length;
                        maxConstructor = constructor;
                    }
                }
            }
            return maxConstructor;
        }

        private ConstructorInfo getConstructorWithMinParameters(Type t)
        {
            ConstructorInfo[] constructors = t.GetConstructors();
            ConstructorInfo minParamConstructor = null;

            foreach (ConstructorInfo constructor in constructors)
            {
                int minLength = constructor.GetParameters().Count<ParameterInfo>();
                if (minLength == 0)
                {
                    minParamConstructor = constructor;
                    break;
                }
            }
            return minParamConstructor;
        }

        public object CreateByFillingFields(Type t)
        {
            object obj = Activator.CreateInstance(t);
            FieldInfo[] fields = t.GetFields();
            PropertyInfo[] properties = t.GetProperties();

            foreach (FieldInfo field in fields)
            {
                try
                {
                    field.SetValue(obj, generator.GenerateValue(field.FieldType));
                }
                catch (FieldAccessException e)
                {

                }
            }

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite && property.SetMethod.IsPublic)
                {
                    property.SetValue(obj, generator.GenerateValue(property.PropertyType));
                }
            }
            return obj;
        }

        public object CreateByConstructor(ConstructorInfo constructor, Type t)
        {
            object[] parametersValues = new object[constructor.GetParameters().Count<ParameterInfo>()];
            ParameterInfo[] parameters = constructor.GetParameters();
            object result;

            int i = 0;

            foreach (ParameterInfo parameter in parameters)
            {
                parametersValues[i] = generator.GenerateValue(parameter.ParameterType);
                i++;
            }
            try
            {
                result = constructor.Invoke(parametersValues);
            }
            catch (OutOfMemoryException e)
            {
                result = null;
            }
            catch (OverflowException e)
            {
                result = null;
            }

            return result;
        }

        public object Create(Type t)
        {
            object result;
            ConstructorInfo constructorWithParameters;
            ConstructorInfo constructorWithoutParameters;
            int publicFieldCount;
            int publicPropertiesCount;

            generator.AddToCycle(t);
            constructorWithParameters = getConstructorWithMaxParameters(t);
            constructorWithoutParameters = getConstructorWithMinParameters(t);

            publicFieldCount = t.GetFields().Count<FieldInfo>();
            publicPropertiesCount = t.GetProperties().Count<PropertyInfo>();

            if ((constructorWithParameters == null) || ((constructorWithoutParameters != null)
                && (constructorWithParameters.GetParameters().Count<ParameterInfo>() < publicFieldCount + publicPropertiesCount)))
            {
                result = CreateByFillingFields(t);
                Console.WriteLine(result.GetType() + " was created by filling fields");
            }
            else
            {
                result = CreateByConstructor(constructorWithParameters, t);
                Console.WriteLine(result.GetType() + " was created by constructor with parameters");
            }

            generator.RemoveFromCycle(t);
            return result;
        }

        public T Create<T>()
        {
            Type t = typeof(T);
            generator.SetFaker(this);
            return (T)Create(t);
        }
    }
}
