using System;
using System.Linq;
using System.Net.Http.Headers;

namespace _08._Bombs
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
          
            string[] coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] inpurBomb = coordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int row = inpurBomb[0];
                int col = inpurBomb[1];
                Explosion(matrix, row, col);
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {

                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {

                    Console.Write(matrix[row,col]+" ");

                }
                Console.WriteLine();
            }

        }
        static void Explosion(int[,] matrix, int row, int col)
        {
            if (matrix[row, col] <= 0)
            {
                return;
            }
            int powerBomb = matrix[row, col];

            for (int row1 = row - 1; row1 < row + 2; row1++)
            {
                for (int col1 = col - 1; col1 < col + 2; col1++)
                {
                    if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] > 0)
                    {
                        matrix[row1, col1] -= powerBomb;

                    }
                }
            }
        }

        static bool CheckCoordinates(int[,] matrix, int row, int col)
        {
            if(row>=0&&col>=0
                &&row<matrix.GetLength(0)
                && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
