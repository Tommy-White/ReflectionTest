using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class Person
    {
        private int age = 0;
        private string name = String.Empty;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Load()
        {
            if (File.Exists("settings.dat"))
            {
                Type type = this.GetType();

                string propertyName, value;
                string[] temp;
                char[] splitChars = new char[] { '|'};
                PropertyInfo propertyInfo;

                string[] settings = File.ReadAllLines("settings.dat");
                foreach (string s in settings)
                {
                    temp = s.Split(splitChars);
                    if (temp.Length == 2)
                    {
                        propertyName = temp[0];
                        value = temp[1];
                        propertyInfo = type.GetProperty(propertyName);
                        if (propertyInfo != null)
                            this.SetProperty(propertyInfo, value);

                    }
                }
            }
        }

        public void SetProperty(PropertyInfo propertyInfo, object value)
        {
            switch (propertyInfo.PropertyType.Name)
            {
                case "Int32":
                    propertyInfo.SetValue(this, Convert.ToInt32(value), null);
                    break;
                case "String":
                    propertyInfo.SetValue(this, value.ToString(), null);
                    break;
            }
        }

        public void Save()
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            TextWriter tw = new StreamWriter("settings.dat");
            foreach (PropertyInfo propertyInfo in properties)
            {
                tw.WriteLine(propertyInfo.Name + "|" + propertyInfo.GetValue(this, null));
            }
            tw.Close();
        }

    }
}
