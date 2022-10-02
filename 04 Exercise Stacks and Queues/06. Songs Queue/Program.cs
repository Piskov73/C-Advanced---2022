using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> soungs = new Queue<string>(Console.ReadLine()
                .Split(", ").ToArray());
          
            while (soungs.Count>0)
            {
                string comand = Console.ReadLine();
                

                switch (comand)
                {
                    case "Play":
                        if (soungs.Count > 0)
                        {
                            soungs.Dequeue();
                        }
                       
                                
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ",soungs));
                        break;

                    default:
                        string song = comand.Substring(4);
                        if (soungs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            soungs.Enqueue(song);

                        }
                        break;
                }
               
            }
            Console.WriteLine("No more songs!");




        }
    }
}
