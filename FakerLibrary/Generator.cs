using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LR2_SPP
{
    class Generator
    {
        private String pluginName;
        private Assembly assembly;
        private Dictionary<Type, Func<object>> typeDictionary;
        private CollectionGenerator collectionGenerator;
        private List<Type> cycleList;
        private Faker faker;

        public Generator()
        {
            typeDictionary = new Dictionary<Type, Func<object>>();
            collectionGenerator = new CollectionGenerator();

            cycleList = new List<Type>();
            pluginName = "D:\\Code\\Git\\C#\\SPP\\SPP_Faker\\LR2_SPP\\FakerLibrary\\bin\\Debug\\Plugins.dll";
            if (!File.Exists(pluginName))
            {
                throw new InvalidPluginPathException("Wrong plugin's path");
            }

            assembly = Assembly.LoadFile(pluginName);
            typeDictionary = fillDictionary(typeDictionary);
        }

        public void AddToCycle(Type t)
        {
            cycleList.Add(t);
        }

        public void RemoveFromCycle(Type t)
        {
            cycleList.Remove(t);
        }

        public void SetFaker(Faker faker)
        {
            this.faker = faker;
        }

        private Dictionary<Type, Func<object>> fillDictionary(Dictionary<Type, Func<object>> dictionary)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterface(typeof(IGenerator).ToString()) != null)
                {
                    var plugin = assembly.CreateInstance(type.FullName) as IGenerator;
                    if (!dictionary.ContainsKey(plugin.GetValueType()))
                        dictionary.Add(plugin.GetValueType(), plugin.generateValue);
                }
            }
            return dictionary;
        }

        public object GenerateValue(Type t)
        {
            object obj = null;
            Func<object> generatorFunc = null;

            if (t.IsGenericType)
            {
                obj = collectionGenerator.generateList(t.GenericTypeArguments[0], this);
            }
            else if (typeDictionary.TryGetValue(t, out generatorFunc))
                obj = generatorFunc.Invoke();
            else if (!cycleList.Contains(t))
            {
                obj = faker.Create(t);
            }
            return obj;
        }
    }
}
