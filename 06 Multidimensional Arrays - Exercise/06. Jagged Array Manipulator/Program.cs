using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];
            for (int rowInput = 0; rowInput < jaggedMatrix.GetLength(0); rowInput++)
            {
                double[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
                jaggedMatrix[rowInput] = input;
            }

            AnalysisMatrix(jaggedMatrix);
            int row = 0;
            int col = 0;
            int value = 0;
            string[] comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "End")
            {
                row = int.Parse(comand[1]);
                col = int.Parse(comand[2]);
                value = int.Parse(comand[3]);
                if (CheckCoordinatesMatrix(jaggedMatrix, row, col))
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


                comand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            PrintJaggedMatrix(jaggedMatrix);

        }



        static void AnalysisMatrix(double[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.GetLength(0) - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] *= 2;
                        jaggedMatrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedMatrix[row].Length; col++)
                    {
                        jaggedMatrix[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
                    {
                        jaggedMatrix[row + 1][col] /= 2;
                    }
                }
            }
        }

        static bool CheckCoordinatesMatrix(double[][] jaggedMatrix, int row, int col)
        {
            if (row >= 0 && col >= 0
                && row < jaggedMatrix.GetLength(0)
                && col < jaggedMatrix[row].Length)
            {
                return true;
            }
            return false;
        }

        static void PrintJaggedMatrix(double[][] jaggedMatrix)
        {
            for (int i = 0; i < jaggedMatrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(' ', jaggedMatrix[i]));
            }
        }
    }
}
