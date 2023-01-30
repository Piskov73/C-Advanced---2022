using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            int taskToKill = int.Parse(Console.ReadLine());
            while (true)
            {
                int tssk=tasks.Peek();
                int thread=threads.Peek();
                if(tssk==taskToKill)
                {
                    break;
                }
                else if(thread>=tssk)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else 
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ",threads));


        }
    }
}
