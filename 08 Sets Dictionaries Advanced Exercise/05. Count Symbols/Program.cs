using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            var countSimbols = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                AddChar(countSimbols, ch);
            }
            //S: 1 time/s
            foreach (var item in countSimbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }

        static void AddChar(SortedDictionary<char, int> countSimbols, char ch)
        {
            if (!countSimbols.ContainsKey(ch))
            {
                countSimbols[ch] = 0;
            }
            countSimbols[ch]++;
        }
    }
}
