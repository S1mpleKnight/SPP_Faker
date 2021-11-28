using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    public class Bar
    {
        private string fieldString;
        public bool fieldBool;
        public Foo fieldFoo;
        public DateTime fieldDate;

        public string propertyString
        {
            get { return fieldString; }
            set { fieldString = value; }
        }

        public Bar(bool fieldBool, Foo filedFoo, DateTime fieldDate, String fieldString)
        {
            this.fieldBool = fieldBool;
            fieldFoo = filedFoo;
            this.fieldDate = fieldDate;
            propertyString = fieldString;
        }
    }
}
