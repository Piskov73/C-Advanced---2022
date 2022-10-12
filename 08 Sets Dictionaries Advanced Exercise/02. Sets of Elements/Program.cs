using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var first = new HashSet<string>();
            var second = new HashSet<string>();
            int[] n = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int i = 0; i < n[0]; i++)
            {
                first.Add(Console.ReadLine());
            }

            for (int i = 0; i < n[1]; i++)
            {
                second.Add(Console.ReadLine());
            }

            first.IntersectWith(second);
            Console.WriteLine(string.Join(' ',first));
        }
    }
}
