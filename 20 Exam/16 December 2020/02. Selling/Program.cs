using System;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] bakery = new char[size, size];
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
              
                for (int col = 0; col < size; col++)
                {
                    if (input[col] == 'S')
                    {
                        startRow=row;
                        startCol=col;
                    }
                    bakery[row, col] = input[col];
                }
            }
            int sum= 0;
            while (sum<50)
            {
                int row=startRow;
                int col=startCol;
                bakery[row, col] = '-';

                string comand=Console.ReadLine();

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
                if(!CheckingMatrix(row,col,bakery))
                {
                    break;
                }
                if (Char.IsDigit(bakery[row, col]))
                {
                    sum += int.Parse(bakery[row, col].ToString());
                    bakery[row, col] = 'S';
                    startRow=row; startCol=col;

                    continue;
                }
                if (bakery[row, col] == 'O')
                {
                    bakery[row, col] = '-';
                    for (int row1 = 0; row1 < bakery.GetLength(0); row1++)
                    {

                        for (int col1 = 0; col1 < bakery.GetLength(1); col1++)
                        {
                            if (bakery[row1, col1] == 'O')
                            {
                                bakery[row1, col1] = 'S';
                                startRow= row1; startCol = col1;

                            }
                        }

                    }
                    continue;
                }
                bakery[row, col] = 'S';
                startCol= col;
                startRow = row;

            }
            if (sum >= 50)
            {               
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {sum}");
            

            PrintCharMatrix(bakery);
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
