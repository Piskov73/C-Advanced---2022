using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());


            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            char simbol = char.Parse(Console.ReadLine());

            bool end = false;
            int rowSimbol = -1;
            int colSimbol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == simbol)
                    {
                        end = true;

                        rowSimbol = row;
                        colSimbol = col;
                        break;
                    }
                }
                if (end)
                {
                    break;
                }
            }
            if (end)
            {
                Console.WriteLine($"({rowSimbol}, {colSimbol})");
            }
            else
            {
                Console.WriteLine($"{simbol} does not occur in the matrix");
            }
        }
    }
}
