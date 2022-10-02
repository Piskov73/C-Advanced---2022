using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11___Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());

            int sizeBarrel = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int intelligence=int.Parse(Console.ReadLine());

            int numbBulets = bullets.Count;

            while (bullets.Count>0&&locks.Count>0)
            {
                numbBulets -= sizeBarrel;

                for (int i = 0; i < sizeBarrel; i++)
                {
                    if (bullets.Peek() <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");

                        intelligence -= priceBullet;

                        bullets.Pop();

                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");

                        intelligence -= priceBullet;

                        bullets.Pop();
                    }
                    if (bullets.Count == 0 || locks.Count == 0)
                    {
                        break;
                    }
                }
                if (numbBulets > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
