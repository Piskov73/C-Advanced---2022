using System;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = p => Console.WriteLine("Sir "+String.Join(Environment.NewLine+"Sir ",p));
           

            string[] inpur = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            print(inpur);
        }
    }
}
