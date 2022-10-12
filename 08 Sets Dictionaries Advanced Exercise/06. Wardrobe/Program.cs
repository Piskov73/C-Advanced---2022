using System;
using System.Collections.Generic;
using System.Drawing;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Blue -> dress,jeans,hat
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var clothe in clothes)
                {
                    AddInWardrobe(wardrobe, color, clothe);

                }

            }
            string[] search = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            PrintOutput(wardrobe, search);
        }



        static void AddInWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string color, string clothe)
        {
            if (!wardrobe.ContainsKey(color))
            {
                wardrobe[color] = new Dictionary<string, int>();
            }
            if (!wardrobe[color].ContainsKey(clothe))
            {
                wardrobe[color][clothe] = 0;
            }
            wardrobe[color][clothe]++;
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> wardrobe, string[] search)
        {
            string color = search[0];
            string clothe = search[1];
            foreach (var col in wardrobe)
            {
                Console.WriteLine($"{col.Key} clothes:");
                foreach (var item in col.Value)
                {
                    if (col.Key == color && item.Key == clothe)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }

                }
            }
        }
    }
}
