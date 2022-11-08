using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> firstNameSetOfCharacters = (name, sum) => name.Sum(ch => ch) >= sum;

            Func<List<string>, int, Func<string, int, bool>, string> firstName = (names, sum, mathc) =>
            {
                return names.FirstOrDefault(name => mathc(name, sum));
            };
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(firstName(names,sum,firstNameSetOfCharacters));


        }
    }
}
