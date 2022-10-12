using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var forceBook = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                string forceSide = "";
                string forceUser = "";
                if (input.Contains(" | "))
                {
                    string[] side = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    forceSide = side[0];
                    forceUser = side[1];

                    AddSide(forceBook, forceSide, forceUser);
                }
                else if (input.Contains(" -> "))
                {
                    string[] user = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    forceUser = user[0];
                    forceSide = user[1];
                    RemuveUser(forceBook, forceUser);
                    AddSide(forceBook, forceSide, forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }
                input = Console.ReadLine();
            }
            
            PrintForceBook(forceBook);
        }

        static void AddSide(Dictionary<string, List<string>> forceBook, string forceSide, string forceUser)
        {
            if (!forceBook.ContainsKey(forceSide))
            {
                forceBook[forceSide] = new List<string>();
            }
            if (!forceBook[forceSide].Contains(forceUser))
            {
                forceBook[forceSide].Add(forceUser);
            }
        }

        static void RemuveUser(Dictionary<string, List<string>> forceBook, string forceUser)
        {
            foreach (var item in forceBook)
            {
                if (item.Value.Contains(forceUser))
                {
                    item.Value.Remove(forceUser);
                }
            }
        }

        static void PrintForceBook(Dictionary<string, List<string>> forceBook)
        {
            foreach (var item in forceBook.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                if (item.Value.Count == 0)
                {
                    continue;
                }
                
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var user in item.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                
            }
        }
    }
}
