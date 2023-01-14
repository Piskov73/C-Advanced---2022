using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());

            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            int totalNumberOfSwords = 0;

            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }

            };
            while (steel.Count > 0 && carbon.Count > 0)
            {
                int steelTemp = steel.Dequeue();
                int carbonTemp = carbon.Pop();
                int sum = steelTemp + carbonTemp;


                if (sum == 70)
                {
                    swords["Gladius"]++;
                    totalNumberOfSwords++;
                }

                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    totalNumberOfSwords++;
                }

                else if (sum == 90)
                {
                    swords["Katana"]++;
                    totalNumberOfSwords++;
                }

                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    totalNumberOfSwords++;
                }

                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    totalNumberOfSwords++;
                }
                else
                {
                    carbonTemp += 5;
                    carbon.Push(carbonTemp);
                }
            }

            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            if (swords.Count > 0)
            {
                foreach (var item in swords.OrderBy(x => x.Key))
                {
                    if (item.Value > 0)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                }
            }

        }
    }
}
