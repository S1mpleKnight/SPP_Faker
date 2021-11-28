using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    public class TestClass
    {
        private int fieldPrivateInt;
        public List<int> list;
        public Foo foo;
        public Bar bar;
        public int fieldInt;
        public short fieldShort;
        public long fieldLong;
        public double fieldDouble;
        public float fieldFloat;
        public byte fieldByte;
        public string fieldString;
        public bool fieldBool;
        public DateTime fieldDate;

        public string propertyString { get; set; }
        public TestClass propertyTest { get; set; }
        public char propertyChar { get; set; }

        public TestClass(int value1, short value2, string value3)
        {
            fieldPrivateInt = value1;
            fieldShort = value2;
            fieldString = value3;
        }

        public TestClass()
        {

        }
    }
}
