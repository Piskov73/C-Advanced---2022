using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootbox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Stack<int> seconfLootbox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            int sum = 0;
            while (firstLootbox.Count>0&&seconfLootbox.Count>0)
            {
                int first = firstLootbox.Peek();
                int second = seconfLootbox.Pop();
                if((first+second)%2==0)
                {
                    sum += (first + second);
                    firstLootbox.Dequeue();
                }
                else
                {
                    firstLootbox.Enqueue(second);
                }
            }
            if(firstLootbox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum }");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum }");
            }
        }
    }
}
                