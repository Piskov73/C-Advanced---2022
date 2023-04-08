using System;
using System.Linq;

namespace SuperMario
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int live=int.Parse(Console.ReadLine());
            int rowMatrix = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rowMatrix][];
            for (int row = 0; row < rowMatrix; row++)
            {
                
                matrix[row] = Console.ReadLine().ToCharArray();

            }
            int startRow = -1;
            int startCol = -1;
            for (int row = 0; row < rowMatrix; row++)
            {
                bool stop = false;
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        startRow = row; startCol = col;
                        stop = true;
                        break;
                    }
                }
                if (stop) break;
            }
            matrix[startRow][startCol] = '-';
            bool viktori=false;
            while (true)
            {
                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string direction = comand[0];
                int r = int.Parse(comand[1]);
                int c= int.Parse(comand[2]);
                matrix[r][c] = 'B';
                live--;
                int row = startRow;
                int col=startCol;
                int[] temp=DirectionMatrix(direction, row, col);
                row = temp[0];
                col = temp[1];
                if(CheckPositionMatrix(matrix, row, col))
                {
                    if (matrix[row][col] == 'P')
                    {
                        matrix[row][col] = '-';
                        viktori = true;
                        break;
                    }
                    else if (matrix[row][col] == 'B')
                    {
                        startRow=row; 
                        startCol = col;
                        if (live <= 0)
                        {
                            break;
                        }
                        live -= 2;
                        if (live <= 0)
                        {
                            break;
                        }
                        else
                        {
                            matrix[startRow][startCol] = '-';
                        }
                    }
                    else
                    {
                        startRow = row; startCol = col;
                        if (live <= 0) break;
                    }

                    
                }
                else
                {
                    if (live <= 0) break;
                }



            }

            if (viktori)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {live}");
            }
            else
            {
                matrix[startRow][ startCol] = 'X';
                Console.WriteLine($"Mario died at {startRow};{startCol}.");
            }
            PrintJaggedMatrix(matrix);
        }
        static void PrintJaggedMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
        static int[] DirectionMatrix(string direction, int row, int col)
        {
            int[] ints = new int[2];
            switch (direction)
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
            ints[0] = row;
            ints[1] = col;
            return ints;

        }
        static bool CheckPositionMatrix(char[][] matrix, int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix[row].Length)
                return false;
            return true;
        }
    }
}
