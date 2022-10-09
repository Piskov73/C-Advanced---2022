using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var names = new HashSet<string>();

            string input = Console.ReadLine();
            while (input!= "PARTY")
            {
                names.Add(input);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="END")
            {

                names.Remove(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(names.Count);
            foreach (var name in names)
            {
                if (char.IsDigit(name[0]))
                {
                    Console.WriteLine(name);
                }
            }
            foreach (var name in names)
            {
                if (char.IsLetter(name[0]))
                {
                    Console.WriteLine(name);
                }
            }
                
        }
    }
}
