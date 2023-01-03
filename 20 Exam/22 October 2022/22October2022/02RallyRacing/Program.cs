using System;
using System.Linq;

namespace _02RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());

            string car = Console.ReadLine();
            int carRow = 0;
            int carCol = 0;
            int distance = 0;

            string[,] matrix = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
           
            bool finis = false;
            string comand = Console.ReadLine();
            while (comand != "End")
            {
                switch (comand)
                {
                  
                    case "right":
                        carCol++;
                        break;
                    case "left":
                        carCol--;
                        break;
                    case "up":
                        carRow--;
                        break;
                    case "down":
                        carRow++;
                        break;
                }
                if (matrix[carRow, carCol] == ".")
                {
                    distance += 10;
                }
                else if (matrix[carRow, carCol] == "T")
                {
                    distance += 30;
                    matrix[carRow, carCol] = ".";
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == "T")
                            {
                                 carRow = row;
                                 carCol = col;

                                matrix[carRow, carCol] = ".";
                            }
                        }
                    }

                }
                else if (matrix[carRow, carCol] == "F")
                {
                    distance += 10;

                    finis = true;
                    break;
                }



                comand = Console.ReadLine();

            }

            if (finis)
            {
                Console.WriteLine($"Racing car {car} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {car} DNF.");
            }
            Console.WriteLine($"Distance covered {distance} km.");
            matrix[carRow, carCol] = "C";
            PrintCharMatrix(matrix);
        }
        private static void PrintCharMatrix(string[,] matrix)
        {
           

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

