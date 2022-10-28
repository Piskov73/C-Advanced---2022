using System;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> vat = x => x * 1.2M;
            decimal[] addVAT=Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(vat)
                .ToArray();
            foreach (var item in addVAT)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
