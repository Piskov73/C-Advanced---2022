using System;
using System.Linq;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rowJaggedMatrix = int.Parse(Console.ReadLine());
            char[][] jaggedMatrix = new char[rowJaggedMatrix][];
            int startRow = -1;
            int startCol = -1;
            bool victori=false;

            for (int row = 0; row < rowJaggedMatrix; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                jaggedMatrix[row] = input;
                if (input.Contains('M'))
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == 'M')
                        {
                            startRow = row;
                            startCol = i;
                            break;
                        }
                    }
                }

            }
            jaggedMatrix[startRow][startCol] = '-';

            while (true)
            {
                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = startRow;
                int col = startCol;
                int rowB = int.Parse(comand[1]);
                int colB = int.Parse(comand[2]);
                jaggedMatrix[rowB][colB] = 'B';
                switch (comand[0])
                {

                    case "W":
                        row--;
                        break;
                    case "S":
                        row++;
                        break;
                    case "A":
                        col--;
                        break;
                    case "D":
                        col++;
                        break;
                }

                lives--;
               
                if (!ChecJaggedMatrix(jaggedMatrix, row, col))
                {
                    if (lives <= 0)
                    {
                        break;
                    }
                    continue;
                }
                else
                {
                    if (jaggedMatrix[row][col] == 'P')
                    {
                        startCol = col;
                        startRow = row;
                        victori = true;
                        break;
                    }
                    else if(jaggedMatrix[row][col] == 'B')
                    {
                        lives -= 2;

                        if (lives <= 0)
                        {
                            startCol= col;
                            startRow= row;
                            break;
                        }
                        jaggedMatrix[row][col] = '-';
                        startCol = col;
                        startRow = row;
                    }
                    else
                    {
                        startCol = col;
                        startRow = row;
                    }
                }
            }
            if(victori)
            {
                jaggedMatrix[startRow][startCol] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                jaggedMatrix[startRow][startCol] = 'X';
                Console.WriteLine($"Mario died at {startRow};{startCol}.");
            }
                    

            PrintJaggedMatrix(jaggedMatrix);
        }



        static void PrintJaggedMatrix(char[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                Console.WriteLine(String.Join("", jaggedMatrix[row]));
            }
        }
        static bool ChecJaggedMatrix(char[][] jaggedMatrix, int row, int col)
        {
            if(row < 0 || col < 0 || row >= jaggedMatrix.Length || col >= jaggedMatrix[row].Length)
            {
                return false;
            }

            return true;
        }

    }
}
