using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    class GeneratorOfDateTime : IGenerator
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public object generateValue()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            long ticks = start.AddDays(random.Next(range)).Ticks +
                (long)random.Next();
            return new DateTime(ticks);
        }

        public Type GetValueType()
        {
            return typeof(DateTime);
        }
    }
}