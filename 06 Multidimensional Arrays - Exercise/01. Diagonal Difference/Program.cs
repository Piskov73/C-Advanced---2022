using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sumFirstDiagonal = 0;
            for (int i = 0; i < size; i++)
            {
                sumFirstDiagonal += matrix[i, i];
            }
            int sumSecondDiagonal = 0;

            int rows = 0;
            for (int i = size-1; i >= 0; i--)
            {
                sumSecondDiagonal += matrix[rows, i];
                rows++;
            }
            Console.WriteLine($"{Math.Abs(sumFirstDiagonal-sumSecondDiagonal)}");

        }
    }
}
