using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            int count = 0;
            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                {"Bread",0 },
                {"Cake",0 },
                {"Pastry",0 },
                {"Fruit Pie",0 }
                
            };
            while (liquids.Any()&&ingredients.Any())
            {
                int liquid=liquids.Dequeue();
                int ingredient=ingredients.Pop();
                int sum=liquid+ingredient;
                // Bread   25
                // Cake    50
                // Pastry  75
                // Fruit Pie   100
                if (sum==25)
                {
                    if (food["Bread"]==0) count++;
                    food["Bread"]++;
                }
                else if (sum==50) 
                {
                    if (food["Cake"] == 0) count++;
                    food["Cake"]++;
                }
                else if (sum == 75)
                {
                    if (food["Pastry"] == 0) count++;
                    food["Pastry"]++;
                }
                else if (sum == 100)
                {
                    if (food["Fruit Pie"] == 0) count++;
                    food["Fruit Pie"]++;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }

                
            }
            if(count==4)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine( "Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any()) 
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in food.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
           

        }
    }
}
