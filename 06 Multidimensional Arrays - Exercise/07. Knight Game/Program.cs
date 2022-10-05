using System;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            AddMatrixChar(matrix);
            int deletedItems = 0;

            while (true)
            {
                int bestCounter = 0;
                int remuvRow = -1;
                int remuvCol = -1;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }
                        else
                        {
                            int counter = AnalysisMatrix(matrix, row, col);
                            if(counter > bestCounter)
                            {
                                bestCounter=counter;
                                remuvRow = row;
                                remuvCol = col;
                            }
                        }
                    }
                }
                if (bestCounter == 0)
                {
                    break;
                }
                matrix[remuvRow, remuvCol] = '0';
                deletedItems++;
                    
            }
            Console.WriteLine(deletedItems);

        }



        static void AddMatrixChar(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static int AnalysisMatrix(char[,] matrix, int row, int col)
        {
            int counter = 0;

            int row1 = row - 2;
            int col1 = col - 1;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row - 1;
            col1 = col - 2;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row - 2;
            col1 = col +1;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row - 1;
            col1 = col + 2;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row + 1;
            col1 = col + 2;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row + 2;
            col1 = col +1;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row + 2;
            col1 = col - 1;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }
            row1 = row +1;
            col1 = col - 2;
            if (CheckCoordinates(matrix, row1, col1) && matrix[row1, col1] == 'K')
            {
                counter++;
            }

            return counter;
        }

        static bool CheckCoordinates(char[,] matrix, int row1, int col1)
        {
            if (row1 >= 0 && col1 >= 0
                && row1 < matrix.GetLength(0)
                && col1 < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
