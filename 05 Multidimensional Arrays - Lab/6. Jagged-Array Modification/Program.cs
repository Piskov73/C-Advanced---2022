using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[size][];

            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                jaggedMatrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            while (comand[0] != "END")
            {
                int row = int.Parse(comand[1]);
                int col = int.Parse(comand[2]);
                int value = int.Parse(comand[3]);

                // bool val= ValidationZizeMatrix(jaggedMatrix,row,col);

                if (ValidationZizeMatrix(jaggedMatrix, row, col))
                {
                    switch (comand[0])
                    {
                        case "Add":
                            jaggedMatrix[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedMatrix[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            PrintJuggedMatrx(jaggedMatrix);
        }

        static bool ValidationZizeMatrix(int[][] jaggedMatrix, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < jaggedMatrix.GetLength(0) && col < jaggedMatrix[row].Length)
            {
                return true;
            }
            return false;
        }

        static void PrintJuggedMatrx(int[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(' ', jaggedMatrix[row]));
            }
        }
    }
}
