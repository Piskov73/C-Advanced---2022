using System;

namespace _02Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            int totalSum = 0;
            bool outMatrix= false;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();



                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    matrix[row, col] = input[col];
                }
            }

            while (totalSum<65)
            {
                int row=startRow;
                int col=startCol;
                matrix[row,col] = '-';
                string comand= Console.ReadLine();
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
                if (CheckingMatrix(row,col,matrix))
                {
                    if (matrix[row,col] == '-')
                    {
                        matrix[row, col] = 'A';
                        startRow = row;
                        startCol = col;
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        matrix[row, col] = '-';

                        for (int row1 = 0; row1 < matrix.GetLength(0); row1++)
                        {
                            bool flag=false;
                            for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                            {
                                if (matrix[row1, col1] == 'M')
                                {
                       
                                     startRow= row1; startCol = col1;
                                    matrix[startRow, startCol] = 'A';
                                    flag = true;
                                    break;

                                }
                            }
                            if (flag) break;

                        }
                    }
                    else
                    {
                        totalSum += int.Parse(matrix[row, col].ToString());
                        matrix[row, col] = 'A';
                        startRow = row;
                        startCol = col;

                    }
                }
                else
                {
                   outMatrix= true;
                    break;
                }
            }
            if(outMatrix)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {totalSum} gold coins.");

            PrintCharMatrix(matrix);
        }

        static void PrintCharMatrix(char[,] matrix)
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
