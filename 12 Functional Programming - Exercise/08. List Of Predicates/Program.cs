using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int[], List<int>> listPredicates = (numbMax, numbers) =>
            {
                List<int> output = new List<int>();
                for (int i = 1; i <= numbMax; i++)
                {
                    bool flag=true;
                    foreach (var numb in numbers)
                    {
                        if (i % numb == 0)
                        {
                            continue;
                        }
                        flag=false;
                        break;
                    }
                    if (flag)
                    {
                        output.Add(i);
                    }
                }

                return output;
            };
            int numb = int.Parse(Console.ReadLine());


            int[] numbs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            List<int> output = listPredicates(numb,numbs);
            Console.WriteLine(string.Join(' ',output));

        }
    }
}
