using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace _01BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waters = new Queue<double>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(double.Parse).ToList());

            Stack<double> flours = new Stack<double>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList());
            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                {"Croissant",0 },
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 }

            };
         


            while (waters.Count > 0 && flours.Count > 0)
            {
                double water = waters.Dequeue();
                double flour = flours.Pop();
                double sum = water + flour;
                if (sum * 0.5 == water && sum * 0.5 == flour)
                {
                    products["Croissant"]++;
                }
                else if (sum * 0.4 == water && sum * 0.6 == flour)
                {
                    products["Muffin"]++;
                }
                else if (sum * 0.3 == water && sum * 0.7 == flour)
                {
                    products["Baguette"]++;
                }
                else if (sum * 0.2 == water && sum * 0.8 == flour)
                {
                    products["Bagel"]++;
                }
                else
                {
                    products["Croissant"]++;
                    flour -= water;
                    flours.Push(flour);
                }
            }

            foreach (var product in products.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }
            if(waters.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ",waters)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flours.Count> 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flours)}");
            }else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
