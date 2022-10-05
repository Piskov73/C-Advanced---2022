using System;
using System.Linq;

namespace _10._RadioactiveVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatix = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] lair = new char[sizeMatix[0], sizeMatix[1]];


            int[] startCordinate = new int[2];

            AddMatrix(lair, startCordinate);
            int row = startCordinate[0];
            int col = startCordinate[1];

            char[] comands = Console.ReadLine().ToCharArray();

            bool hepyEnd = false;
            bool deed = false;

            foreach (var comand in comands)
            {
                lair[row, col] = '.';
                int tempRow = row;
                int tempCol = col;
                switch (comand)
                {
                    case 'L':
                        tempCol--;
                        if (CheckCoordinstes(lair, tempRow, tempCol))
                        {
                            if (lair[tempRow, tempCol] == '.')
                            {
                                lair[tempRow, tempCol] = 'P';
                            }
                            else if (lair[tempRow, tempCol] == 'B')
                            {
                                deed = true;
                            }

                            row = tempRow;
                            col = tempCol;
                        }
                        else
                        {
                            hepyEnd = true;
                        }
                        break;
                    case 'R':
                        tempCol++;
                        if (CheckCoordinstes(lair, tempRow, tempCol))
                        {
                            if (lair[tempRow, tempCol] == '.')
                            {
                                lair[tempRow, tempCol] = 'P';
                            }
                            else if (lair[tempRow, tempCol] == 'B')
                            {
                                deed = true;
                            }

                            row = tempRow;
                            col = tempCol;
                        }
                        else
                        {
                            hepyEnd = true;
                        }
                        break;
                    case 'U':
                        tempRow--;
                        if (CheckCoordinstes(lair, tempRow, tempCol))
                        {
                            if (lair[tempRow, tempCol] == '.')
                            {
                                lair[tempRow, tempCol] = 'P';
                            }
                            else if (lair[tempRow, tempCol] == 'B')
                            {
                                deed = true;
                            }

                            row = tempRow;
                            col = tempCol;
                        }
                        else
                        {
                            hepyEnd = true;
                        }
                        break;
                    case 'D':
                        tempRow++;
                        if (CheckCoordinstes(lair, tempRow, tempCol))
                        {
                            if (lair[tempRow, tempCol] == '.')
                            {
                                lair[tempRow, tempCol] = 'P';
                            }
                            else if (lair[tempRow, tempCol] == 'B')
                            {
                                deed = true;
                            }

                            row = tempRow;
                            col = tempCol;
                        }
                        else
                        {
                            hepyEnd = true;
                        }
                        break;


                }

                lair = MuuvetRabet(lair, ref deed);

                if (deed || hepyEnd)
                {
                    break;
                }
            }
            PrintMatrix(lair);
            if (hepyEnd)
            {
                Console.WriteLine($"won: {row} {col}");
            }
            if (deed)
            {
                Console.WriteLine($"dead: {row} {col}");
            }              
        }

        static void AddMatrix(char[,] matrix, int[] startCordinate)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inpyt = Console.ReadLine().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inpyt[col];
                    if (matrix[row, col] == 'P')
                    {
                        startCordinate[0] = row;
                        startCordinate[1] = col;
                    }
                }

            }
        }


        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckCoordinstes(char[,] matrix, int row, int col)
        {
            if (row >= 0 && col >= 0
                && row < matrix.GetLength(0)
                && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static char[,] MuuvetRabet(char[,] matrix, ref bool deed)
        {
            char[,] newMatrix = CopiMatrix(matrix);

            for (int row = 0; row < newMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < newMatrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (CheckCoordinstes(matrix, row - 1, col))
                        {
                            if (newMatrix[row - 1, col] == '.')
                            {
                                newMatrix[row - 1, col] = 'B';
                            }
                            else if (newMatrix[row - 1, col] == 'P')
                            {
                                newMatrix[row - 1, col] = 'B';
                                deed = true;
                            }
                        }
                        if (CheckCoordinstes(matrix, row + 1, col))
                        {
                            if (newMatrix[row +1, col] == '.')
                            {
                                newMatrix[row + 1, col] = 'B';
                            }
                            else if (newMatrix[row + 1, col] == 'P')
                            {
                                newMatrix[row +1, col] = 'B';
                                deed = true;
                            }
                        }
                        if (CheckCoordinstes(matrix, row, col - 1))
                        {
                            if (newMatrix[row , col-1] == '.')
                            {
                                newMatrix[row , col-1] = 'B';
                            }
                            else if (newMatrix[row, col-1] == 'P')
                            {
                                newMatrix[row , col-1] = 'B';
                                deed = true;
                            }
                        }
                        if (CheckCoordinstes(matrix, row, col + 1))
                        {
                            if (newMatrix[row , col+1] == '.')
                            {
                                newMatrix[row , col+1] = 'B';
                            }
                            else if (newMatrix[row , col+1] == 'P')
                            {
                                newMatrix[row , col+1] = 'B';
                                deed = true;
                            }
                        }
                    }
                }
            }

            return newMatrix;
        }

        static char[,] CopiMatrix(char[,] matrix)
        {
            char[,] newMatris = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    newMatris[row, col] = matrix[row, col];
                }
            }

            return newMatris;

        }
    }

}


