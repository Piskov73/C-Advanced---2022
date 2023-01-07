using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffees = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList());

            Stack<int> milks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                {"Cortado",0 },
                {"Espresso",0 },
                {"Capuccino",0 },
                {"Americano",0 },
                {"Latte",0 },
            };
            while (coffees.Count>0&&milks.Count>0)
            {
                int coffee=coffees.Dequeue();
                int milk=milks.Pop();
                int sum = coffee + milk;
                if(sum==50)
                {
                    // Cortado 50

                    drinks["Cortado"]++;

                }
                else if (sum == 75)
                {
                    //Espresso    75
                    drinks["Espresso"]++;
                }
                else if (sum==100)
                {
                    //Capuccino   100
                    drinks["Capuccino"]++;
                }
                else if (sum == 150)
                {
                    //Americano   150
                    drinks["Americano"]++;
                }
                else if (sum == 200)
                {
                    //Latte   200
                    drinks["Latte"]++;
                }
                else
                {
                    milk -= 5;
                    milks.Push(milk);
                }
            }

            if(milks.Count==0&&coffees.Count==0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            string coffeeLeft = $"Coffee left: {string.Join(", ",coffees)}";
            string milkLeft = $"Milk left: {string.Join(", ", milks)}";

            // Coffee left: none
            //"Milk left: none"
           if(coffees.Count>0)
            {
                Console.WriteLine(coffeeLeft);
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }
           if(milks.Count>0)
            {
                Console.WriteLine(milkLeft);
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }


            foreach (var drink in drinks.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key)) 
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }


        }
    }
}
