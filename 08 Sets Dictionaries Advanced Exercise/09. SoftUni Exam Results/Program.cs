using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"{username}-{language}-{points}".
            var usernames = new Dictionary<string, int>();
            var languages = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "exam finished")
            {
                string username = input[0];
                string language = "";
                int points = 0;
                if (input[1] == "banned")
                {
                    usernames.Remove(username);
                }
                else
                {
                    language = input[1];
                    points = int.Parse(input[2]);
                    AddUsername(usernames, username, points);
                    AddLanguage(languages, language);

                }


                input = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Results:");
            PrintUser(usernames);
            Console.WriteLine("Submissions:");
            PrintLanguage(languages);

        }

        static void AddUsername(Dictionary<string, int> usernames, string username, int points)
        {
            if (!usernames.ContainsKey(username))
            {
                usernames[username] = 0;
            }

            if (usernames[username] < points)
            {
                usernames[username] = points;
            }

        }


        static void AddLanguage(Dictionary<string, int> languages, string language)
        {
            if (!languages.ContainsKey(language))
            {
                languages[language] = 0;
            }
            languages[language]++;

        }


        static void PrintUser(Dictionary<string, int> usernames)
        {
            foreach (var name in usernames.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }
        }

        static void PrintLanguage(Dictionary<string, int> languages)
        {
            foreach (var item in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
