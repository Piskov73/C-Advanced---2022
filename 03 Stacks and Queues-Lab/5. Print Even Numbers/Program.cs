using System;
using System.Collections.Generic;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Queue<int> evenNumbs = new Queue<int>();
            foreach (var item in input)
            {
                int numb=int.Parse(item);
                if (numb % 2 == 0)
                {
                    evenNumbs.Enqueue(numb);
                }
            }

            Console.WriteLine(String.Join(", ",evenNumbs));
        }

    }
}
