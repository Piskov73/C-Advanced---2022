using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var valuesArray=new Dictionary<double,int>();
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            foreach (var item in input)
            {
                if (!valuesArray.ContainsKey(item))
                {
                    valuesArray.Add(item, 0);
                }
                valuesArray[item]++;
            }
            foreach (var item in valuesArray)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
