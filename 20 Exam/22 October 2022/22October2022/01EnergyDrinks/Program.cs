using System;
using System.Collections.Generic;
using System.Linq;

namespace _01EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxCaffeine = 300;

            Stack<int> caffeines = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
          
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            int caffeineDey=0; 

            while (caffeines.Count>0&&drinks.Count>0)
            {
                int caffeine=caffeines.Pop();
                int drink=drinks.Dequeue();
                if(caffeineDey+caffeine*drink<=maxCaffeine)
                {
                    caffeineDey+=drink*caffeine;
                    continue;
                }
               
                drinks.Enqueue(drink);
                caffeineDey -= 30;
                if (caffeineDey < 0)
                {
                    caffeineDey = 0;
                }
            }
            if(drinks.Count>0)
            {
                string str = $"{string.Join(", ",drinks)}";
                Console.WriteLine($"Drinks left: { str}");
                Console.WriteLine($"Stamat is going to sleep with {caffeineDey} mg caffeine.");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
                Console.WriteLine($"Stamat is going to sleep with {caffeineDey} mg caffeine.");
            }
        }
    }
}
