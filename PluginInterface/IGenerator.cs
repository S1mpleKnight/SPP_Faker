using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginInterfaces
{
    public interface IGenerator
    {
        object generateValue();
        Type GetValueType();
    }
}
