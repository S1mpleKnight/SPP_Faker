using LR2_SPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_SPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();

            TestClass result = faker.Create<TestClass>();
        }
    }
}
