using System;

namespace _06CountMethodDoubles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                box.Elements.Add(double.Parse(Console.ReadLine()));
            }
            double compere=double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(compere));
        }
    }
}
