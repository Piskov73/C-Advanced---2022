using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05._Filter_By_Age
{
    class Person
    {
        public string Name { get; set; }

        public  int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
         
            List<Person> info= new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Person person = new Person();
                string[] infoName = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = infoName[0];
                int agePerson = int.Parse(infoName[1]);
                person.Name = name;
                person.Age=agePerson;
                info.Add(person);

              
            }

            string condition = Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            string formst=Console.ReadLine();
            Func<Person, bool> filter = f => true;

            switch (condition)
            {
                case "younger":
                    filter = f => f.Age < age;

                    break;
                case "older":
                    filter = f => f.Age >= age;

                    break;
            }

           var filterInfo = info.Where(filter);

            //•	Format - "name", "age" or "name age"
            StringBuilder sb = new StringBuilder();
            
            switch (formst)
            {
                case "name":
                    foreach (var item in filterInfo)
                    {
                       string str = item.Name;
                        sb.AppendLine(str);
                    }
                    break;
                case "age":
                    foreach (var item in filterInfo)
                    {
                       string str = $"{item.Age}";
                        sb.AppendLine(str);
                    }
                    break;
                case "name age":
                    foreach (var item in filterInfo)
                    {
                        string str = $"{item.Name} - {item.Age}";
                        sb.AppendLine(str);
                    }
                    break;
            }

            Console.WriteLine(sb.ToString());


        }
    }
}
