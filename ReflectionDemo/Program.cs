using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Load();
            if ((person.Age > 0) && (person.Name != String.Empty))
            {
                Console.WriteLine("Hi " + person.Name + " - you are " + person.Age + " years old!");
            }
            else
            {
                Console.WriteLine("I don't seem to know much about you. Please enter the following information:");
                Type type = typeof(Person);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    Console.WriteLine(propertyInfo.Name + ":");
                    person.SetProperty(propertyInfo, Console.ReadLine());
                }
                person.Save();
                Console.WriteLine("Thank you! I have saved your information for next time.");
            }
            Console.ReadKey();
        }
    }
}
