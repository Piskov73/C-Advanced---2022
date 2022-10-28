using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> firstCapitalLetter = st=> char.IsUpper(st[0]);
            Console.WriteLine(String.Join(Environment.NewLine,Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Where(x=>firstCapitalLetter(x))));

        }
    }
}
