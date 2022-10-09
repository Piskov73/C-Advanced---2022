using System;
using System.Collections.Generic;

namespace _05CitiesContinenCountr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                AddContinent(continents);
            }

            PrintOutput(continents);
        }



        static void AddContinent(Dictionary<string, Dictionary<string, List<string>>> continent)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string continentName = input[0];
            string countriName = input[1];
            string citiName = input[2];
            if (!continent.ContainsKey(continentName))
            {
                continent[continentName] = new Dictionary<string, List<string>>();
            }
            if (!continent[continentName].ContainsKey(countriName))
            {
                continent[continentName][countriName] = new List<string>();
            }
            continent[continentName][countriName].Add(citiName);

        }

        static void PrintOutput(Dictionary<string, Dictionary<string, List<string>>> continents)
        {
            //Europe:
            //Bulgaria->Sofia, Plovdiv
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }


        }
    }
}
