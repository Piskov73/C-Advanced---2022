using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> bottels = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int wastedLittersOfWater = 0;

            while (cups.Count>0&&bottels.Count>0)
            {
                if (bottels.Peek() >= cups.Peek())
                {
                    wastedLittersOfWater += bottels.Pop() - cups.Dequeue();
                }
                else
                {
                    int capacityCup = cups.Peek();
                    while (true)
                    {
                        if (capacityCup <= bottels.Peek())
                        {
                            wastedLittersOfWater += bottels.Pop() - capacityCup;
                            cups.Dequeue();
                            break;
                        }
                        else
                        {
                            capacityCup -= bottels.Pop();
                        }

                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ',bottels)}");
                Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ',cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
            }

        }
    }
}
