using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int capacitiBox = int.Parse(Console.ReadLine());

            int countBox = 1;
            int capaciti = capacitiBox;
            while (clothes.Count>0)
            {
                if (capaciti - clothes.Peek() >= 0)
                {
                    capaciti -= clothes.Pop();
                }
                else
                {
                    countBox++;
                    capaciti = capacitiBox;
                }
            }
            Console.WriteLine(countBox);

        }
    }
}
