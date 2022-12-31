using System;

namespace _088Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] infoPerson=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] infoBeer=Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] infoBank=Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, string, string> person = new Threeuple<string, string, string>
            {
                Threeuple1 = $"{infoPerson[0]} {infoPerson[1]}",
                Threeuple2 = infoPerson[2],
                Threeuple3= infoPerson[3],
            };
            Threeuple<string,int,bool> drinkBeer= new Threeuple<string, int, bool>
            {
                Threeuple1 = infoBeer[0],
                Threeuple2 = int.Parse(infoBeer[1]),
                Threeuple3= infoBeer[2]== "drunk"
            };
            Threeuple<string, double, string> bankBalance = new Threeuple<string, double, string>
            {
                Threeuple1= infoBank[0],
                Threeuple2 = double.Parse(infoBank[1]),
                Threeuple3 = infoBank[2]
            };

            Console.WriteLine(person);
            Console.WriteLine(drinkBeer);
            Console.WriteLine(bankBalance);
        }
    }
}
