using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n= int.Parse(Console.ReadLine());

            var userNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                userNames.Add(Console.ReadLine());
            }
            foreach (var name in userNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
