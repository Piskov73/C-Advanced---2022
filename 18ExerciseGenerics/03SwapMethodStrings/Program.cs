using System;

namespace _03SwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int count=int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                box.Items.Add(Console.ReadLine());
            }
            Console.WriteLine(box.Swap(Console.ReadLine()));
        }
    }
}
