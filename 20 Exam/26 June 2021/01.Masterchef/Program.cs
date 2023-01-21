using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());

            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());

            
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce",0 },
                {"Green salad",0 },
                {"Chocolate cake",0 },
                {"Lobster",0 }

            };
            int count = 0;

            while (ingredients.Count>0&&freshness.Count>0)
            {
                int firstElement=ingredients.Peek();
                
                int secondElement=freshness.Peek();
                if(firstElement==0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int result = firstElement * secondElement;
                // Dipping sauce   150
                //Green salad 250
                //Chocolate cake  300
                //Lobster 400
                if(result==150)
                {
                    if (dishes["Dipping sauce"]==0)
                    {
                        count++;
                    }
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue() ;
                    freshness.Pop();
                }
                else if (result == 250)
                {
                    if (dishes["Green salad"] == 0)
                    {
                        count++;
                    }
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == 300)
                {
                    if (dishes["Chocolate cake"] == 0)
                    {
                        count++;
                    }
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (result == 400)
                {
                    if (dishes["Lobster"] == 0)
                    {
                        count++;
                    }
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    ingredients.Dequeue();
                    freshness.Pop();
                    ingredients.Enqueue(firstElement + 5);
                }




            }

            if(count==4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine( "You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                int sum = 0;
                foreach (int i in ingredients)
                {
                    sum+= i;
                }
                Console.WriteLine($"Ingredients left: {sum}");
            }
            foreach (var item in dishes.OrderBy(x=>x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($" # {item.Key } --> {item.Value}");
                }
            }


        }
    }
}
