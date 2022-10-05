using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "END")
            {
                if (comand[0] == "swap" && comand.Length == 5)
                {
                    int rowFirst = int.Parse(comand[1]);
                    int colFirst = int.Parse(comand[2]);
                    int rowsSwcond = int.Parse(comand[3]);
                    int colSecond = int.Parse(comand[4]);
                    if (CheckCoordinates(matrix, rowFirst, colFirst) && CheckCoordinates(matrix, rowsSwcond, colSecond))
                    {
                        string temp = matrix[rowFirst, colFirst];
                        matrix[rowFirst, colFirst] = matrix[rowsSwcond, colSecond];
                        matrix[rowsSwcond, colSecond] = temp;

                        PrintMartix(matrix);

                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static bool CheckCoordinates(string[,] matrix, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1))
            {
                return true;
            }

            Console.WriteLine("Invalid input!");
            return false;
        }

        static void PrintMartix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
