using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ClimbThePeaks
{
    internal class Program
    {
        public class Mountain
        {
            public string Peak { get; set; }
            public int Height { get; set; }
        }
        static void Main(string[] args)
        {
            List<Mountain> mountain = new List<Mountain>();
            //  Vihren  80
            //Kutelo  90
            //Banski Suhodol  100
            //Polezhan    60
            //Kamenitza   70
            mountain.Add(new Mountain { Peak = "Vihren", Height = 80 });
            mountain.Add(new Mountain { Peak = "Kutelo", Height = 90 });
            mountain.Add(new Mountain { Peak = "Banski Suhodol", Height = 100 });
            mountain.Add(new Mountain { Peak = "Polezhan", Height = 60 });
            mountain.Add(new Mountain { Peak = "Kamenitza", Height = 70 });

            List<string> peak = new List<string>();

            Stack<int> foodPortions = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            Queue<int> staminaQuantities = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());

            for (int i = 0; i < 7; i++)
            {
                int strength = foodPortions.Pop() + staminaQuantities.Dequeue();
                if (strength >= mountain[0].Height)
                {
                    peak.Add(mountain[0].Peak);
                    mountain.RemoveRange(0, 1);

                }
                if(mountain.Count==0)
                {
                    break;
                }
            }
            if(mountain.Count==0)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");

                Console.WriteLine("Conquered peaks:");
                foreach (var item in peak)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                if (peak.Count>0)
                {
                    Console.WriteLine("Conquered peaks:");
                    foreach (var item in peak)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
