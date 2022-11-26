using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] peoples = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person newPerson = new Person(peoples[0], int.Parse(peoples[1]));

                family.AddMember(newPerson);
            }

            Person oldPerson = family.GetOldestMember();
            Console.WriteLine($"{oldPerson.Name} {oldPerson.Age}");
        }
    }
}
