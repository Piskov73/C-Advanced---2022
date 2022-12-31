using System;

namespace _07Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] name= Console .ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] beer= Console .ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] num= Console .ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> person = new Tuple<string, string>
            {
                FirstTuple = $"{name[0]} {name[1]}",
                
                SecondTuple = name[2]
                
            };
            Tuple<string, int> drinkBeer = new Tuple<string, int>
            {
                FirstTuple = beer[0],
                SecondTuple = int.Parse(beer[1])
            };
            Tuple<int, double> numb = new Tuple<int, double>
            {
                FirstTuple = int.Parse(num[0]),
                SecondTuple = double.Parse(num[1])
            };
            Console.WriteLine(person);
            Console.WriteLine(drinkBeer);
            Console.WriteLine(numb);
        }
    }
}
