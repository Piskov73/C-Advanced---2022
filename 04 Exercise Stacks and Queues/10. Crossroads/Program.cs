using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> crossroads = new Queue<string>();

            int totalCarsPassed = 0;

            bool end = true;
            string comand = Console.ReadLine();
            while (comand != "END")
            {
                if (comand == "green")
                {
                    int light = greenLight;
                    while (light > 0 && crossroads.Count > 0)
                    {
                        if (light - crossroads.Peek().Length >= 0)
                        {
                            light -= crossroads.Dequeue().Length;
                            totalCarsPassed++;
                        }
                        else if (light + freeWindow - crossroads.Peek().Length >= 0)
                        {
                            crossroads.Dequeue();
                            totalCarsPassed++;
                            break;
                        }
                        else
                        {
                            end = false;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{crossroads.Peek()} was hit at {crossroads.Peek()[light + freeWindow]}.");
                            break;
                        }
                    }
                }
                else
                {
                    crossroads.Enqueue(comand);
                }
                if (!end)
                {
                    break;
                }

                comand = Console.ReadLine();
            }

            if (end)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }

        }
    }
}
