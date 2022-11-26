using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Define_a_Class_Person
{
    public class Person
    {
        private string name;

        private int age;

        public string Name { get { return name; } set { name = value; } }

        public int Age { get { return age; } set { age = value; } }

    }
}
