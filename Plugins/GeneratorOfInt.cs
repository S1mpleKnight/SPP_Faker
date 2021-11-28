using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
     class GeneratorOfInt : IGenerator
     {
          private Random random = new Random((int)DateTime.Now.Ticks);

          public object generateValue()
          {
               int result;
               do
               {
                    result = random.Next();
               } while (result == 0);
               return (Int32)result;
          }

          public Type GetValueType()
          {
               return typeof(Int32);
          }
     }
}
