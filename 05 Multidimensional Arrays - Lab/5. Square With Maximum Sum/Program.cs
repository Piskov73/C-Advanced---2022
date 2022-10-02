using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
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
            return matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
        }

        static void Print(int[,] matrix, int startRow, int startCol, int maxSum)
        {
            for (int row = startRow; row <= startRow+1; row++)
            {
                for (int col = startCol; col <= startCol+1; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
