using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    class CollectionGenerator
    {
        private Random random;

        public CollectionGenerator()
        {
            random = new Random((int)DateTime.Now.Ticks);
        }

        public object generateList(Type type, Generator generator)
        {
            object list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            int count = (Byte)random.Next();

            for (int i = 0; i < count; i++)
            {
                ((IList)list).Add(generator.GenerateValue(type));
            }
            return list;
        }

    }
}
