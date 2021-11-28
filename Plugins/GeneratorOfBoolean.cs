using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    class GeneratorOfBoolean : IGenerator
    {

        public object generateValue()
        {
            return (Boolean)true;
        }

        public Type GetValueType()
        {
            return typeof(Boolean);
        }

    }
}
