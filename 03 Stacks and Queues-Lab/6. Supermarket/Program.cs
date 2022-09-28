using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string customerName = Console.ReadLine();
            Queue<string> customer = new Queue<string>();
            while (customerName!="End")
            {
                if(customerName== "Paid" && customer.Count > 0)
                {
                    while (customer.Count>0)
                    {
                        Console.WriteLine(customer.Dequeue());
                    }
                }
                else
                {
                    customer.Enqueue(customerName);
                }
                customerName = Console.ReadLine();
            }
            //"{count} people remaining." 
            Console.WriteLine($"{customer.Count} people remaining.");
        }
    }
}
