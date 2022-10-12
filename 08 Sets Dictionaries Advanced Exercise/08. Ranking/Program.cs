using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            string[] inputContest = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            while (inputContest[0] != "end of contests")
            {
                string contest = inputContest[0];
                string passwordContest = inputContest[1];

                AddContestsAndPassword(contests, contest, passwordContest);

                inputContest = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
            }

            string[] candidateInterns = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

            var infoInterns = new Dictionary<string, Dictionary<string, int>>();

            while (candidateInterns[0] != "end of submissions")
            {
                string contest = candidateInterns[0];
                string password = candidateInterns[1];
                string nameInterns = candidateInterns[2];
                int points = int.Parse(candidateInterns[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    AddInterns(infoInterns, nameInterns, contest, points);
                }
                candidateInterns = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            string bestInterns = "";
            int bestPoints = 0;
            foreach (var name in infoInterns)
            {
                int sum = 0;
                foreach (var item in name.Value)
                {
                    sum += item.Value;
                }
                if (sum > bestPoints)
                {
                    bestPoints = sum;
                    bestInterns = name.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestInterns} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            Print(infoInterns);

        }



        static void AddContestsAndPassword(Dictionary<string, string> contests, string contest, string passwordContest)
        {
            if (!contests.ContainsKey(contest))
            {
                contests.Add(contest, passwordContest);
            }
        }


        static void AddInterns(Dictionary<string, Dictionary<string, int>> infoInterns, string nameInterns, string contest, int points)
        {
            if (!infoInterns.ContainsKey(nameInterns))
            {
                infoInterns[nameInterns] = new Dictionary<string, int>();
            }
            if (!infoInterns[nameInterns].ContainsKey(contest))
            {
                infoInterns[nameInterns][contest] = 0;
            }
            if (infoInterns[nameInterns][contest] < points)
            {
                infoInterns[nameInterns][contest] = points;
            }
        }

        static void Print(Dictionary<string, Dictionary<string, int>> infoInterns)
        {
            foreach (var name in infoInterns.OrderBy(x=>x.Key))
            {
                Console.WriteLine(name.Key);
                foreach (var item in name.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
