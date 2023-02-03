using System;

namespace _02Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix=int.Parse(Console.ReadLine());
            char[,] matrix= new char[sizeMatrix,sizeMatrix];
            matrix=CharMatrix(matrix);

            int[] startIndex = GetStartIndex(matrix, 'S');
            int startRow = startIndex[0];
            int startCol= startIndex[1];
            int food = 0;
            while (food<10)
            {
                int row=startRow;
                int col= startCol;
                matrix[row, col] = '.';
                string comand=Console.ReadLine();
                int[]muve=GetMovement(comand,row,col);
                row = muve[0];
                col= muve[1];
                if (CheckingMatrix(row, col, matrix))
                {
                    if (matrix[row, col] == '*')
                    {
                        food++;
                        matrix[row, col] = 'S';
                        startCol= col;
                        startRow= row;
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        int[] index = GetStartIndex(matrix, 'B');
                        row= index[0];
                        col= index[1];
                        matrix[row, col] = 'S';
                        startRow= row;
                        startCol= col;
                    }
                    else
                    {
                        matrix[row, col] = 'S';
                        startRow = row;
                        startCol = col;

                    }
                }
                else
                {
                    break;
                }

            }
            if(food==10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {food }");
            PrintCharMatrix(matrix);

        }


        static char[,] CharMatrix(char[,] matrix)
        {
            char[,] charMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < charMatrix.GetLength(1); col++)
                {
                    charMatrix[row, col] = input[col];
                }

            }

            return charMatrix;
        }

        static void PrintCharMatrix(char[,] matrix)
        {
            //PrintCharMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static int[] GetStartIndex(char[,] matrix, char ch)
        {
            int startRow = -1; int startCol = -1;
            bool stop = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ch)
                    {
                        startRow = row;
                        startCol = col;
                        stop = true;
                        break;
                    }
                }
                if (stop)
                {
                    break;
                }
            }
            int[] index = new int[] { startRow, startCol };
            return index;
        }
        static int[] GetMovement(string comand, int row, int col)
        {
            switch (comand)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }
            return new int[] { row, col };
        }
        static bool CheckingMatrix(int row, int col, char[,] matrix)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
