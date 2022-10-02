using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
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
            Queue<int> queueInt = new Queue<int>(input);
            for (int i = 0; i < manipulator[1]; i++)
            {
                if (queueInt.Count > 0)
                {
                    queueInt.Dequeue();
                }
            }
            if (queueInt.Contains(manipulator[2]))
            {
                Console.WriteLine("true");
            }
            else if (queueInt.Count > 0)
            {
                Console.WriteLine(queueInt.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
