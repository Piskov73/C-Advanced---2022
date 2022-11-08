using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string comand = Console.ReadLine();
            while (comand!= "Party!")
            {
                string[] tolken=comand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action=tolken[0];
                string filter=tolken[1];
                string velio=tolken[2];
                if(action== "Remove")
                {
                    people.RemoveAll(GetPredicat(filter, velio));
                }
                else
                {
                    List<string> doublePeople = people.FindAll(GetPredicat(filter, velio));

                    int index=people.FindIndex(GetPredicat(filter, velio));
                    if (index != -1)
                    {
                        people.InsertRange(index, doublePeople);
                    }
                }

                comand = Console.ReadLine();
            }

            if (people.Any())
            {
                Console.WriteLine(string.Join(", ",people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicat(string filter, string velio)
        {
            switch (filter)
            {
                case "StartsWith":
                    return x => x.StartsWith(velio);
                    
                case "EndsWith":
                    return x => x.EndsWith(velio);
                  
                case "Length":
                    return x => x.Length == int.Parse(velio);
                    

                default:
                    return null;
                    
            }
        }
    }
}
