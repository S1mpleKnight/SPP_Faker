using PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
     class GeneratorOfString : IGenerator
     {
          private Random random = new Random((int)DateTime.Now.Ticks);

          public object generateValue()
          {
               int length = random.Next(1, 20);
               string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890^@*+-+%()!?";
               StringBuilder result = new StringBuilder(length);
               for (int i = 0; i < length; i++)
               {
                    int pos = random.Next(0, symbols.Length);
                    result.Append(symbols[pos]);
               }
               return (String)result.ToString();
          }

          public Type GetValueType()
          {
               return typeof(String);
          }
     }
}
