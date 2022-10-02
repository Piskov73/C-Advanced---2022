using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            Queue<int> orders=new Queue<int>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Console.WriteLine(orders.Max());

            while (orders.Count>0)
            {
                if (quantityFood - orders.Peek() >= 0)
                {

                    quantityFood -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(' ',orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
