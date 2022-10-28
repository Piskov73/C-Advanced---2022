using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int> parse=n=>int.Parse(n);

            Func<int[], int> count = n => n.Length;

            Func<int[], int> sum = n => n.Sum();

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parse).ToArray();

            Console.WriteLine(count(input));
            Console.WriteLine(sum(input));
        }
    }
}
