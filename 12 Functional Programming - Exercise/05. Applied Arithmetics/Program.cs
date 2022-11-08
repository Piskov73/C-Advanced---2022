using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[], string> action = (numbs, operation) =>
            {
                
                switch (operation)
                {
                    case "add":
                        for (int i = 0; i < numbs.Length; i++)
                        {
                            numbs[i]++;
                        }
                        break;
                    case "multiply":
                        for (int i = 0; i < numbs.Length; i++)
                        {
                            numbs[i]*=2;
                        }
                        break;
                    case "subtract":
                        for (int i = 0; i < numbs.Length; i++)
                        {
                            numbs[i]--;
                        }
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ',numbs));
                        break;

                }

            };


            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string comand = Console.ReadLine();
            while (comand != "end")
            {

                action(numbers,comand);

                comand = Console.ReadLine();

            }
        }
    }
}
