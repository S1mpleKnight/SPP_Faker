using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
     class GeneratorOfByte : IGenerator
     {
          private Random random = new Random((int)DateTime.Now.Ticks);

          public object generateValue()
          {
               Byte result;
               do {
                    result = (Byte)random.Next();
               } while (result == 0);   
               return result;
          }

          public Type GetValueType()
          {
               return typeof(Byte);
          }
     }
}
