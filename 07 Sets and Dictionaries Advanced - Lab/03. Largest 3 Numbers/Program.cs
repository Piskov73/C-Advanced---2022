using System;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] sorted = input.OrderByDescending(x => x).ToArray();

            if (sorted.Length <= 3)
            {
                Console.WriteLine(String.Join(" ",sorted));
            }
            else
            {
                var newSorte = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    newSorte[i] = sorted[i];
                }
                Console.WriteLine(String.Join(" ", newSorte));
            }
        }
    }
}
