using System;
using System.Collections.Generic;

namespace _02WallDestroye
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int startRow = -1;
            int startCol = -1;
            int countOfHoles = 1;
            int countOfRods = 0;
            bool flag=false;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }

                }
            }

            matrix[startRow, startCol] = '*';

            string comand = Console.ReadLine().ToLower();
            while (comand != "end")
            {
                int row = startRow;

                int col = startCol;

                switch (comand)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "left":
                        col--;
                        break;
                    case "right":
                        col++;
                        break;
                }

                if(CheckParameters(row, col, matrix))
                {
                    comand = Console.ReadLine().ToLower();
                    continue;
                }
                if (matrix[row,col] == '-')
                {
                    matrix[row, col] = '*';
                    countOfHoles++;
                    startRow= row;
                    startCol= col;
                }
                else if (matrix[row, col] == 'R')
                {
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[row, col] == 'C')
                {
                    matrix[row, col] = 'E';
                    countOfHoles++;
                    flag= true;
                    break;
                }
                else if (matrix[row, col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!" );
                    startRow = row;
                    startCol = col;
                }

                comand = Console.ReadLine().ToLower();
            }
            if (flag)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
            {
                matrix[startRow, startCol] = 'V';
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            PrintMatrix(matrix);
        }

        static bool CheckParameters(int row, int col, char[,] matrix)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static void PrintMatrix(char[,] matrix)
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
