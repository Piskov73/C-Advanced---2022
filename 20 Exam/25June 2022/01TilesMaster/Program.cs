using System;
using System.Collections.Generic;
using System.Linq;

namespace _01TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> area = new Dictionary<string, int>()
            {
                {"Sink",0 },
                {"Oven",0 },
                {"Countertop",0 },
                {"Wall",0 },
                {"Floor",0 }

            };
            var whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            var greyTiles = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int white = whiteTiles.Pop();
                int grwy = greyTiles.Dequeue();
                if (white == grwy)
                {
                    int areaTile = white + grwy;
                    // Sink    40
                    if(areaTile==40) 
                    {
                        area["Sink"]++;
                    }
                    //Oven    50
                    else if (areaTile == 50)
                    {
                        area["Oven"]++;
                    }
                    //Countertop  60
                    else if (areaTile == 60)
                    {
                        area["Countertop"]++;
                    }
                    //Wall    70
                    else if (areaTile == 70)
                    {
                        area["Wall"]++;

                    }
                    else
                    {
                        area["Floor"]++;
                    }


                }
                else
                {
                    whiteTiles.Push(white / 2);
                    greyTiles.Enqueue(grwy);
                }

            }

            //"White tiles left: none"
            //"Grey tiles left: none"
            string outputWhiteTiles = whiteTiles.Count == 0 ? "none":String.Join(", ", whiteTiles);
            string outputGreyTiles = greyTiles.Count == 0 ? "none":String.Join(", ", greyTiles);
            Console.WriteLine($"White tiles left: {outputWhiteTiles}");
            Console.WriteLine($"Grey tiles left: {outputGreyTiles}");

            foreach (var item in area.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}
