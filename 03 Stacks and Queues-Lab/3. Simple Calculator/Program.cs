using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            Stack<string> caluculator = new Stack<string>();
            foreach (var stringInput in input)
            {
                caluculator.Push(stringInput);
            }
            int sum = 0;
            while (caluculator.Count>0)
            {
                if (caluculator.Peek() != "+" && caluculator.Peek() != "-")
                {
                    sum = int.Parse(caluculator.Pop());
                    continue;
                }
                if(caluculator.Peek()== "+")
                {
                    caluculator.Pop();
                    sum += int.Parse(caluculator.Pop());
                }
                else if(caluculator.Peek()== "-")
                {
                    caluculator.Pop();
                    sum -= int.Parse(caluculator.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}
