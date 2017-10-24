using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    class TestClassforInstantiate
    {
       

        private int testValue = 42;

        public TestClassforInstantiate()
        {
        }

        public TestClassforInstantiate(int init)
        {
            testValue = init;
        }

        public int TestMethod(int numberToAdd)
        {
            return this.testValue + numberToAdd;
        }
    }
}
