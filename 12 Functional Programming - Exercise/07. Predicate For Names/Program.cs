using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int,bool> predikatName=(str,numb)=>str.Length<=numb;

            int n = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> output = input.Where(x => predikatName(x, n)).ToList();
            Console.WriteLine(String.Join(Environment.NewLine,output));
        }
    }
}
