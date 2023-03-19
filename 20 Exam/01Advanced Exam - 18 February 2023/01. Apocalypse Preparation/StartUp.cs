namespace ApocalypsePreparation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> medicaments = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Dictionary<string, int> healings = new Dictionary<string, int>()
            {
                // Patch   30
                //Bandage 40
                //MedKit  100
                ["Patch"] = 0,
                ["Bandage"] = 0,
                ["MedKit"] = 0,


            };
            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int textile = textiles.Dequeue();
                int medicament = medicaments.Peek();
                int sum = textile + medicament;
                if (sum == 30)
                {
                    healings["Patch"]++;
                    medicaments.Pop();
                }
                else if (sum == 40)
                {
                    healings["Bandage"]++;
                    medicaments.Pop();
                }
                else if (sum == 100)
                {
                    healings["MedKit"]++;
                    medicaments.Pop();
                }
                else if (sum >100)
                {
                    
                    healings["MedKit"]++;
                    sum -= 100;
                    medicaments.Pop();
                    medicament = medicaments.Pop() + sum;
                    medicaments.Push(medicament);

                }
                else
                {
                    medicament = medicaments.Pop() + 10;
                    medicaments.Push(medicament);
                }
            }
            if (textiles.Count == 0&&medicaments.Count>0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (medicaments.Count == 0&&textiles.Count>0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            foreach (var item in healings.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            if(medicaments.Count> 0) 
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ",medicaments)}");
            }
            if(textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ",textiles)}");
            }

        }
    }
}
