using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BeaverAt_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

                   
            char[,] matrix = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            int countWood = 0;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'B')
                    {
                        startRow= row;
                        startCol = col;
                    }
                    if (input[col] >= 'a' && input[col] <= 'z')
                    {
                        countWood++;
                    }
                    matrix[row, col] = input[col];
                }
            }
            bool finishWood = false;
            Stack<char> woods = new Stack<char>();


            string comand =Console.ReadLine();


            while (comand!="end")
            {
                int row=startRow;
                int col=startCol;
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
                if (CheckingMatrix(row,col,matrix))
                {
                    if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = '-';
                      
                        switch (comand)
                        {
                            case "up":
                                if (row > 0)
                                {
                                    row = 0;
                                }
                                else
                                {
                                    row = n - 1;
                                }
                                break;
                            case "down":
                                if (row < n - 1)
                                {
                                    row = n - 1;
                                }
                                else
                                {
                                    row = 0;
                                }
                                break;
                            case "left":
                                if (col > 0)
                                {
                                    col= 0;
                                }
                                else
                                {
                                    col= n - 1;
                                }
                                break;
                            case "right":
                                if (col < n - 1)
                                {
                                    col = n - 1;
                                }
                                else
                                {
                                    col = 0;
                                }
                                break;
                                                       
                        }
                        if (matrix[row, col] >= 'a' && matrix[row, col] <= 'z')
                        {
                            woods.Push(matrix[row, col]);
                            matrix[startRow, startCol] = '-';
                            matrix[row, col] = 'B';
                            startCol = col;
                            startRow = row;
                            countWood--;
                            if (countWood == 0)
                            {
                                finishWood = true;
                                break;
                            }
                        }
                        else
                        {
                            matrix[startRow, startCol] = '-';
                            matrix[row, col] = 'B';
                            startCol = col;
                            startRow = row;
                        }

                    }
                    else if (matrix[row,col]>='a'&& matrix[row, col] <= 'z')
                    {
                        woods.Push(matrix[row, col]);
                        matrix[startRow, startCol] = '-';
                        matrix[row, col] = 'B';
                        startCol= col;
                        startRow = row;
                        countWood--;
                        if (countWood == 0)
                        {
                            finishWood= true;
                            break;
                        }
                    }
                    else
                    {
                        matrix[startRow, startCol] = '-';
                        matrix[row, col] = 'B';
                        startCol = col;
                        startRow = row;
                    }
                            
                }
                else
                {
                    if(woods.Count > 0)
                    {
                        woods.Pop();
                    }
                }

                comand = Console.ReadLine();
            }

            if (finishWood)
            {
                Console.WriteLine($"The Beaver successfully collect {woods.Count} wood branches: {string.Join(", ",woods.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countWood} branches left.");
            }
         


            PrintCharMatrix(matrix);

        }

        static void PrintCharMatrix(char[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckingMatrix(int row, int col, char[,] matrix)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
