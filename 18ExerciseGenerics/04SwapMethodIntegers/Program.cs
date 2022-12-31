using System;

namespace _04SwapMethodIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                box.Items.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(box.Swap(Console.ReadLine()));
        }
    }
}
