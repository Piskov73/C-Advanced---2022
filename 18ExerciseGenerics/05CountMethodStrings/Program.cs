using System;

namespace _05CountMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int count= int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Items.Add(input);
            }
            string compare= Console.ReadLine();
            Console.WriteLine(box.Count(compare));
        }
    }
}
