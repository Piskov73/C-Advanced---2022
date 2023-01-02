using System;
using System.Collections.Generic;

namespace _02PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startRowW = -1;
            int startColW = -1;
            int startRowB = -1;
            int startColB = -1;
            string[,] chessBoard = new string[8, 8];
            string abs = "abcdefgh";
            string def = "87654321";

            for (int row = 0; row < 8; row++)
            {

                for (int col = 0; col < 8; col++)
                {
                    chessBoard[row, col] = $"{abs[col]}{def[row]}";
                }
            }


            int n = 8;

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'b')
                    {
                        startRowB = row;
                        startColB = col;
                    }
                    if (input[col] == 'w')
                    {
                        startRowW = row;
                        startColW = col;
                    }
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                int tempRowW = -1;
                int tempColW = -1;
                tempRowW = startRowW - 1;
                tempColW = startColW - 1;
                if (CheckCharMatroxArea(tempRowW, tempColW, matrix) && matrix[tempRowW, tempColW] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessBoard[tempRowW, tempColW]}.");
                    break;
                }
                tempRowW = startRowW - 1;
                tempColW = startColW + 1;
                if (CheckCharMatroxArea(tempRowW, tempColW, matrix) && matrix[tempRowW, tempColW] == 'b')
                {
                    Console.WriteLine($"Game over! White capture on {chessBoard[tempRowW, tempColW]}.");
                    break;
                }
                tempRowW = startRowW - 1;
                tempColW = startColW;
                if (tempRowW > 0)
                {
                    matrix[tempRowW, tempColW] = 'w';

                    startRowW = tempRowW;
                    startColW = tempColW;
                }
                else
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessBoard[tempRowW, tempColW]}.");
                    break;
                }
                int tempRowB = -1;
                int tempColB = -1;
                tempRowB = startRowB + 1;
                tempColB = startColB - 1;
                if (CheckCharMatroxArea(tempRowB, tempColB, matrix) && matrix[tempRowB, tempColB] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessBoard[tempRowW, tempColW]}.");
                    break;
                }
                tempRowB = startRowB + 1;
                tempColB = startColB+ 1;
                if (CheckCharMatroxArea(tempRowB, tempColB, matrix) && matrix[tempRowB, tempColB] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {chessBoard[tempRowW, tempColW]}.");
                    break;
                }
                tempRowB = startRowB + 1;
                tempColB = startColB;
                if (tempRowB < 7)
                {
                    matrix[tempRowB, tempColB] = 'b';

                    startRowB = tempRowB;
                    startColB = tempColB;
                }
                else
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessBoard[tempRowB, tempColB]}.");
                    break;
                }

            }


        }

        static bool CheckCharMatroxArea(int row,int col, char[,] matrix)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }

    }
}
