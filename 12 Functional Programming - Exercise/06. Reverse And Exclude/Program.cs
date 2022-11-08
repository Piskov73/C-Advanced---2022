using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int,int,bool> func=(x,y) => x%y!=0;
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse().ToList();
            int y=int.Parse(Console.ReadLine());

            List<int> output = input.Where(x => func(x, y)).ToList();
            Console.WriteLine(String.Join(' ',output));
            

            
        }
    }
}
