using System;
using System.Diagnostics.SymbolStore;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];
            int countsCoal = 0;

            AddMatrixChar(matrix);
            int startRoe = -1;
            int startCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        countsCoal++;
                    }
                    if (matrix[row, col] == 's')
                    {
                        startRoe = row;
                        startCol = col;
                    }

                }
            }

            bool end=false;

            for (int i = 0; i < comand.Length; i++)
            {
                switch (comand[i])
                {
                    //left, right, up, and down
                    case "left":
                        if (CheckMatrix(matrix, startRoe, startCol - 1))
                        {                          
                            startCol--;
                            if (matrix[startRoe,startCol] == 'c')
                            {
                                matrix[startRoe, startCol] = '*';
                                countsCoal--;
                            }
                            if (matrix[startRoe, startCol] == 'e')
                            {
                                end = true;
                            }
                        }
                        break;
                    case "right":
                        if (CheckMatrix(matrix, startRoe, startCol + 1))
                        {                          
                            startCol++;
                            if (matrix[startRoe, startCol] == 'c')
                            {
                                matrix[startRoe, startCol] = '*';
                                countsCoal--;
                            }
                            if (matrix[startRoe, startCol] == 'e')
                            {
                                end = true;
                            }
                        }

                        break;
                    case "up":

                        if (CheckMatrix(matrix, startRoe-1, startCol))
                        {                           
                            startRoe--;
                            if (matrix[startRoe, startCol] == 'c')
                            {
                                matrix[startRoe, startCol] = '*';
                                countsCoal--;
                            }
                            if (matrix[startRoe, startCol] == 'e')
                            {
                                end = true;
                            }
                        }
                        break;
                    case "down":
                        if (CheckMatrix(matrix, startRoe + 1, startCol))
                        {
                            
                            startRoe++;
                            if (matrix[startRoe, startCol] == 'c')
                            {
                                matrix[startRoe, startCol] = '*';
                                countsCoal--;
                            }
                            if (matrix[startRoe, startCol] == 'e')
                            {
                                end = true;
                            }

                        }
                        break;
                }
                if (countsCoal == 0)
                {
                    break;
                }
            }
            if (end)
            {
                Console.WriteLine($"Game over! ({startRoe}, {startCol})");
            }
            else
            {
                if(countsCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRoe}, {startCol})");
                }
                else
                {
                    Console.WriteLine($"{countsCoal} coals left. ({startRoe}, {startCol})");
                }
            }
        }
        static void AddMatrixChar(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        static bool CheckMatrix(char[,] matrix, int row, int col)
        {
            if(row>=0&&col>=0&& row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
