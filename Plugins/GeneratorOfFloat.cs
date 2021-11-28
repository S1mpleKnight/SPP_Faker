using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
     class GeneratorOfFloat : IGenerator
     {
          private Random random = new Random((int)DateTime.Now.Ticks);

          public object generateValue()
          {
               Double result;
               do
               {
                    result = random.NextDouble();
               } while (result == 0.0);
               return (Single)random.NextDouble();
          }

          public Type GetValueType()
          {
               return typeof(Single);
          }
     }
}
