using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            for (int row = 0; row < size[0]- 2; row++)
            {


                for (int col = 0; col < size[1] - 2; col++)
                {
                    int sum = MaxSum(matrix, row, col);
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Print(matrix, startRow, startCol, maxSum);


        }

        static int MaxSum(int[,] matrix, int row, int col)
        {
            int sum = 0;
            for (int i = row; i < row+3; i++)
            {
                for (int a = col; a < col+3; a++)
                {
                    sum += matrix[i, a];
                }
            }
            return sum;
        }
        static void Print(int[,] matrix, int startRow, int startCol, int maxSum)
        {
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startRow; row < startRow+3; row++)
            {
                for (int col = startCol; col < startCol+3; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
