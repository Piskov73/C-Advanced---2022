using System;

namespace _02NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startRow = -1;
            int startCol = -1;

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    matrix[row, col] = input[col];
                }

            }

            int minesCount = 0;
            int shipCount = 0;
            while (true)
            {
                matrix[startRow, startCol] = '-'; 
              
                string comand= Console.ReadLine();
                switch (comand)
                {
                    case "right":
                        startCol++;
                        break;
                    case "left":
                        startCol--;
                        break;
                    case "down":
                        startRow++;
                        break;
                    case "up":
                        startRow--;
                        break;
                }
                if (matrix[startRow,startCol]=='-')
                {
                    matrix[startRow, startCol] = 'S';
                }
                else if(matrix[startRow, startCol] == 'C')
                {
                    matrix[startRow, startCol] = 'S';
                    shipCount++;
                    if (shipCount == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }
                else if(matrix[startRow, startCol] == '*')
                {
                    matrix[startRow, startCol] = 'S';
                    minesCount++;
                    if (minesCount==3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{startRow}, {startCol}]!");
                        break;             
                    }
                }
            }


            PrintCharMatrix(matrix);

        }
        private static void PrintCharMatrix(char[,] matrix)
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
    }
}
