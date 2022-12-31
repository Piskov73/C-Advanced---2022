using System;

namespace _01BoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<string> box=new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
              box.Items.Add(Console.ReadLine());
            }
            Console.WriteLine(box);
        }
    }
}
