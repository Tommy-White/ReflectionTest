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
    }
}
