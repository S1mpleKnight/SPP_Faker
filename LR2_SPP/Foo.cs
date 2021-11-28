using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    public class Foo
    {
        public string fieldString;
        public TestClass fieldTest;
        public Bar fieldBar;

        public string str { get; set; }

        public Foo(string str)
        {
            fieldString = str;
        }

        public Foo()
        {

        }
    }
}
