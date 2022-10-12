using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection=new Dictionary<string,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (!collection.ContainsKey(input))
                {
                    collection[input]=0;
                }
                collection[input]++;

            }

            foreach (var item in collection)
            {
                if (item.Value%2==0 )
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
