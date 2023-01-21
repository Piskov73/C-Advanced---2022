using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList());

            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToList());
            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int guest = guests.Peek();
                int plate = plates.Pop();

                if (guest - plate <= 0)
                {
                    wastedFood += plate - guest;
                    guests.Dequeue();
                }
                else
                {
                    guest-= plate;
                    while (guest > 0 && plates.Count > 0)
                    {
                        plate = plates.Pop();
                        if (guest - plate <= 0)
                        {
                            wastedFood += plate - guest;
                            guests.Dequeue();
                            break;
                        }
                        guest -= plate;
                    }
                }



            }

            if(plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ',plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(' ',guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
