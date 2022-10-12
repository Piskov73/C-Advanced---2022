using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vLogger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "Statistics")
            {
                string comand = input[1];
                string vloggername = input[0];
                switch (comand)
                {
                    case "joined":
                        AddUsername(vLogger, vloggername);
                        break;
                    case "followed":
                        string vloggerFollowed = input[2];

                        AddVlogger(vLogger, vloggername, vloggerFollowed);

                        break;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            PrintOutput(vLogger);
        }
        static void AddUsername(Dictionary<string, Dictionary<string, SortedSet<string>>> vLogger, string vloggername)
        {
            if (!vLogger.ContainsKey(vloggername))
            {
                vLogger[vloggername] = new Dictionary<string, SortedSet<string>>();

                vLogger[vloggername]["followers"] = new SortedSet<string>();
                vLogger[vloggername]["following"] = new SortedSet<string>();
            }
        }
        static void AddVlogger(Dictionary<string, Dictionary<string, SortedSet<string>>> vLogger, string vloggername, string vloggerFollowed)
        {
            if (vLogger.ContainsKey(vloggername) && vLogger.ContainsKey(vloggerFollowed) && vloggername != vloggerFollowed)
            {
                vLogger[vloggerFollowed]["followers"].Add(vloggername);
                vLogger[vloggername]["following"].Add(vloggerFollowed);
            }
        }
        static void PrintOutput(Dictionary<string, Dictionary<string, SortedSet<string>>> vLogger)
        {
            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            int number = 1;
            foreach (var vlogger in vLogger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                if (number == 1)
                {
                    Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                    //*  JennaMarbles
                    foreach (var item in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {item}");
                    }
                    number++;
                }
                else
                {
                    Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                    number++;
                }
            }
            
        }
    }
}
