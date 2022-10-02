using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> ints = new Stack<int>();


            for (int i = 0; i < n; i++)
            {
                int[] action = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                switch (action[0])
                {
                    case 1:
                        ints.Push(action[1]);
                        break;
                    case 2:
                        if (ints.Count > 0)
                        {
                            ints.Pop();
                        }
                        break;
                    case 3:
                        if (ints.Count > 0)
                        {
                            Console.WriteLine(ints.Max());
                        }
                        break;
                    case 4:
                        if (ints.Count > 0)
                        {
                            Console.WriteLine(ints.Min());
                        }
                        break;

                }
            }
            Console.WriteLine(String.Join(", ",ints));
        }
    }
}
