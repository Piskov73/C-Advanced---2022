using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _01FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList());

            int wreath = 0;
            int flower = 0;

            while (lilies.Count > 0&&roses.Count>0)
            {
                int lilie = lilies.Pop();
                int rose = roses.Dequeue();
                int sumFlower = lilie + rose;
                if (sumFlower == 15)
                {
                    wreath++;
                }
                else if (sumFlower < 15)
                {
                    flower += sumFlower;
                }
                else
                {
                    while (sumFlower > 15)
                    {
                        sumFlower -= 2;
                        if (sumFlower == 15)
                        {
                            wreath++;
                        }
                        if (sumFlower < 15)
                        {
                            flower += sumFlower;
                        }
                    }
                }


            }
            wreath += flower / 15;
            if (wreath >= 5)
            {

                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {

                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }

        }
    }
}
