using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> oddEven = n => true;
            int[] interval = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string filter = Console.ReadLine();
            switch (filter)
            {
                case "odd":
                    oddEven = n => n % 2 != 0;
                    break;

                case "even":
                    oddEven = n => n % 2 == 0;
                    break;
            }
            List<int> input = new List<int>();
            for (int i = interval[0]; i <= interval[1]; i++)
            {
                input.Add(i);
            }

            var filterList = input.FindAll(oddEven);

            Console.WriteLine(String.Join(' ',filterList));

        }
    }
}
