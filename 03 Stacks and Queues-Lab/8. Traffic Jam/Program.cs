using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> traffic = new Queue<string>();
            int greenLight = int.Parse(Console.ReadLine());
            string comand=Console.ReadLine();
            int counter = 0;
            while (comand!="end")
            {
                if (comand == "green")
                {
                    for (int i = 0; i < greenLight; i++)
                    {
                        if (traffic.Count > 0)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            counter++;
                            continue;
                        }
                        break;

                    }
                }
                else
                {
                    traffic.Enqueue(comand);
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
