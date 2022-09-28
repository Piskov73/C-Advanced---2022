using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stackInt = new Stack<int>();
            int[] numbs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var numb in numbs)
            {
                stackInt.Push(numb);
            }

            string comand = Console.ReadLine().ToLower();
            while (comand != "end")
            {
                string[] action = comand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (action[0])
                {
                    case "add":
                        int n1 = int.Parse(action[1]);
                        int n2 = int.Parse(action[2]);
                        stackInt.Push(n1);
                        stackInt.Push(n2);
                        break;
                    case "remove":
                        int n = int.Parse(action[1]);

                        if (stackInt.Count >= n)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                stackInt.Pop();
                            }
                        }

                        break;

                }

                comand = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stackInt.Sum()}");
        }
    }
}
