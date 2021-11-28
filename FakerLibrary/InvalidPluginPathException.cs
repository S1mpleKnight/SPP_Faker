using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    class InvalidPluginPathException : Exception
    {
        public InvalidPluginPathException(string message) : base(message)
        {

        }
    }
}
