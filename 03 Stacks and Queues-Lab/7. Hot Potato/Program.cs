using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> hotPatato=new Queue<string>(input);
            int n=int.Parse(Console.ReadLine());
            while (hotPatato.Count>1)
            {
                for (int i = 1; i < n; i++)
                {
                    string temp = hotPatato.Dequeue();
                    hotPatato.Enqueue(temp);
                }
                Console.WriteLine($"Removed {hotPatato.Dequeue()}");
            }
            Console.WriteLine($"Last is {hotPatato.Peek()}");
        }
    }
}
