using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Queue<int> scarves = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse).ToList());
            int expensiveSet = int.MinValue;
            List<int > sets = new List<int>();

            while (hats.Count>0&&scarves.Count>0)
            {
                int hat = hats.Peek();
                int scarf = scarves.Peek();
                if (scarf > hat)
                {
                    hats.Pop();
                    
                }
                else if(scarf == hat)
                {
                    hats.Pop();
                    scarves.Dequeue();
                    hats.Push(hat+1);
                }
                else
                {
                    hats.Pop();
                    scarves.Dequeue();
                    int sum = hat + scarf;
                    sets.Add(sum);
                    if(sum>expensiveSet)
                    {
                        expensiveSet = sum;
                    }
                }



            }

            Console.WriteLine($"The most expensive set is: {expensiveSet}");
            Console.WriteLine(string.Join(" ",sets));

        }
    }
}
