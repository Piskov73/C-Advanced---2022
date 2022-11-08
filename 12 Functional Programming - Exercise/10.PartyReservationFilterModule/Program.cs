using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            List<string> peoples = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string action = Console.ReadLine();
            while (action != "Print")
            {
                string[] token = action.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string comand = token[0];
                string filter = token[1];
                string parameter = token[2];
                if (comand == "Add filter")
                {
                    filters.Add(filter + parameter, GetPredicat(filter, parameter));
                }
                else
                {
                    filters.Remove(filter + parameter);
                }

                action = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                peoples.RemoveAll(filter.Value);
            }
            Console.WriteLine(string.Join(' ',peoples));
        }

        private static Predicate<string> GetPredicat(string filter, string parameter)
        {
            
            switch (filter)
            {
                case "Starts with":
                    return str => str.StartsWith(parameter);
                    
                case "Ends with":
                    return str => str.EndsWith(parameter);
                    
                case "Length":
                    return str => str.Length == int.Parse(parameter);

                case "Contains":
                    return str => str.Contains(parameter);
                    
            }


            return null;
        }
    }
}
