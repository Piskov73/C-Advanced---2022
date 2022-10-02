using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] manipulator = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackInt = new Stack<int>(input);
            for (int i = 0; i < manipulator[1]; i++)
            {
                if (stackInt.Count > 0)
                {
                    stackInt.Pop();
                    continue;
                }

                
            }

            if (stackInt.Contains(manipulator[2]))
            {
                Console.WriteLine("true");
            }
            else if(stackInt.Count>0)
            {
                Console.WriteLine(stackInt.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
