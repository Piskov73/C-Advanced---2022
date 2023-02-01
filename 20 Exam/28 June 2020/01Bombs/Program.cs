using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());

            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            bool datura = false;
            bool cherry = false;
            bool smoke = false;

            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs",0 },
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs",0 }
                
            };
            //   •	Datura Bombs: 40
            //•	Cherry Bombs: 60
            //•	Smoke Decoy Bombs: 120
            while (effects.Any()&&casings.Any()) 
            {
                int effect=effects.Peek();
                int casing = casings.Pop();
                int sum = effect + casing;
                if(sum==40)
                {
                    bombs["Datura Bombs"]++;
                    effects.Dequeue();
                    if (bombs["Datura Bombs"] == 3)
                    {
                        datura= true;
                    }
                }
                else if (sum==60)
                {
                    bombs["Cherry Bombs"]++;
                    effects.Dequeue();
                    if (bombs["Cherry Bombs"] == 3)
                    {
                        cherry = true;
                    }
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    effects.Dequeue();
                    if (bombs["Smoke Decoy Bombs"] == 3)
                    {
                        smoke = true;
                    }
                }
                else
                {
                    casings.Push(casing - 5);
                }
                if (datura && cherry && smoke) break;
            }
            if(datura&&cherry&&smoke)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else 
            {
                Console.WriteLine( "You don't have enough materials to fill the bomb pouch."); 
            }
            if (effects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ",casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
