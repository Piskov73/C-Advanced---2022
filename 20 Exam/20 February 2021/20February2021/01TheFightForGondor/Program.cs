using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _01TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int numberWaves=int.Parse(Console.ReadLine());
            Queue<int> platesDefense = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Stack<int> orcs = new Stack<int>();
            int plate =platesDefense.Peek();
            for (int i = 1; i <= numberWaves; i++)
            {
                orcs=new Stack<int> (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
                if(i%3==0)
                {
                    platesDefense.Enqueue(int.Parse(Console.ReadLine()));
                }
                int orc=orcs.Peek();
                while (platesDefense.Count>0&&orcs.Count>0)
                {


                    if(orc>=plate)
                    {
                        orc-=plate;
                        platesDefense.Dequeue();
                        if(platesDefense.Count>0)
                        {
                            plate=platesDefense.Peek() ;
                        }
                        if (orc > 0)
                        {
                            orcs.Pop();
                            orcs.Push(orc) ;
                            orc=orcs.Peek() ;
                        }
                        else
                        {
                            orcs.Pop();
                            if (orcs.Count > 0)
                            {
                                orc = orcs.Peek();
                            }
                        }
                    }
                    else
                    {
                        while (orcs.Count>0&&platesDefense.Count>0) 
                        {
                            if(plate>=orc)
                            {
                                plate-=orc;
                                orcs.Pop();
                                if (orcs.Count > 0)
                                {
                                    orc=orcs.Peek();
                                }
                                if(plate==0)
                                {
                                    platesDefense.Dequeue() ;
                                    if (platesDefense.Count > 0)
                                    {
                                        plate= platesDefense.Peek() ;
                                    }
                                }

                            }
                            else
                            {
                                orc -= plate;
                                orcs.Pop();
                                orcs.Push(orc) ;
                                platesDefense.Dequeue() ;
                                if (platesDefense.Count > 0)
                                {
                                    plate= platesDefense.Peek() ;
                                }
                            }
                        }

                    }


                }
                if (platesDefense.Count == 0)
                {
                    break;
                }
            }

            if (platesDefense.Count > 0)
            {
                List<int > plates = new List<int>(platesDefense);
                plates[0]= plate;
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ",plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ",orcs)}");
            }
        }
    }
}
