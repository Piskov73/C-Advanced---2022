using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                pumps.Enqueue(pump);

            }

            int numbPump = 0;
            while (true)
            {
                bool end = true;

                int tanc = 0;

                foreach (var item in pumps)
                {
                    tanc += item[0];
                    if (tanc - item[1] >= 0)
                    {
                        tanc -= item[1];
                    }
                    else
                    {
                        end=false;
                        numbPump++;
                        break;
                    }
                    
                }
                if (end)
                {
                    break;
                }
                int[] temp = pumps.Dequeue();
                pumps.Enqueue(temp);
            }
            Console.WriteLine(numbPump);
        }

    }
}

