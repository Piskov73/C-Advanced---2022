using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            Console.WriteLine(DateModifier.DifferenceBetweenDates(startDate, endDate)); 

        }
    }
}
