using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    /// <summary>
    /// OverView:Reflection allows you to write code that can inspect various aspects about the code itself.
    /// Demo:How can I change the value of a variable during runtime, only by knowing its name? 
    /// </summary>
    class Program
    {
        private static int a = 5, b = 10, c = 20;

        static void Main(string[] args)
        {
            TypeUsage();
            Console.WriteLine();
            ExecutingAssembly();
            Console.WriteLine();
            InstantiateByReflection();
            Console.WriteLine();
            Console.WriteLine("a+b+c=" + (a + b + c));
            Console.WriteLine("Please enter the name of the variable that you wish to change during the runtime:");
            string varName = Console.ReadLine();
            Type t = typeof(Program);
            FieldInfo fieldInfo = t.GetField(varName, BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null)
            {
                Console.WriteLine("The current value of " + fieldInfo.Name + " is " + fieldInfo.GetValue(null) +
                                  ". You may enter a new value now:");
                string newValue = Console.ReadLine();
                int newInt;
                if (int.TryParse(newValue,out newInt))
                {
                    fieldInfo.SetValue(null, newInt);
                    Console.WriteLine("a+b+c=" + (a + b + c));
                }

                Console.ReadKey();
            }
        }

        private static void TypeUsage()
        {
            string test = "test";
            Console.WriteLine(test.GetType().Name);  //Name property return the currency Type
            Console.WriteLine(typeof(Int32).FullName); //Name property return the currency Type NameSpace.Class etc
            Console.WriteLine(typeof(Program).FullName);
            Console.ReadKey();
        }

        private static void ExecutingAssembly()
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); //In this term we own two Types in executing assmbly NewClass & Program
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (Type t in assemblyTypes)
                Console.WriteLine(t.Name);
            Console.ReadKey();
        }

        private static void InstantiateByReflection()
        {
            Type testType = typeof(TestClassforInstantiate);
            ConstructorInfo ctor1 = testType.GetConstructor(System.Type.EmptyTypes);
            var t=new Type[1] { typeof(int) };
            ConstructorInfo ctor2 = testType.GetConstructor(t);
            if (ctor1 != null)
            {
                object instance = ctor1.Invoke(null);
                MethodInfo methodInfo = testType.GetMethod("TestMethod");
                Console.WriteLine("Default constractor invoke instance calling method:" + methodInfo.Invoke(instance, new object[] { 10 }));
            }
            if (ctor2 != null)
            {
                object instance = ctor2.Invoke(new object[]{10});
                MethodInfo methodInfo = testType.GetMethod("TestMethod");
                Console.WriteLine("Custom constractor invoke instance calling method:" + methodInfo.Invoke(instance, new object[] {10}));
            }
            Console.ReadKey();
        }
    }
}
