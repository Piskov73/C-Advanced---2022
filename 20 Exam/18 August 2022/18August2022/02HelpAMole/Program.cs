using System;

namespace _02HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n =int.Parse(Console.ReadLine()) ;

            char[,] matrix = new char[n, n];
            int startRow = -1;
            int startCol=-1 ;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'M')
                    {
                        startRow= row;
                        startCol= col;
                    }
                    matrix[row, col] = input[col];
                }
            }
            int points = 0;
            bool end=false;
            string comand=Console.ReadLine();
            while (comand!="End")
            {
                int row=startRow; int col=startCol;

               

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

                if (CheckingMatrix(row, col, matrix))
                {
                    if (matrix[row, col] == '-')
                    {
                        matrix[startRow, startCol] = '-';
                        matrix[row, col] = 'M';
                        startRow=row; startCol= col;
                    }
                    else if(matrix[row, col] == 'S')
                    {
                        points -= 3;
                        matrix[startRow, startCol] = '-';
                        matrix[row, col] = '-';
                        for (int row1 = 0; row1 < matrix.GetLength(0); row1++)
                        {
                            bool flag= false;
                            for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                            {

                                if (matrix[row1, col1] == 'S')
                                {
                                    startRow= row1; startCol = col1;
                                    flag= true;
                                    break;
                                }
                                
                            }
                            if (flag) break;
                        }
                        matrix[startRow, startCol] = 'M'; 

                    }
                    else if (Char.IsDigit(matrix[row, col]))
                    {
                       
                        points += int.Parse(matrix[row, col].ToString());
                        matrix[startRow, startCol] = '-';
                        matrix[row, col] = 'M';
                        startRow = row; startCol = col;
                    }

                    
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    
                }
                if (points >= 25)
                {
                    end=true; break;
                }
                        

                comand = Console.ReadLine();
            }

            if(end)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }


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
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >=matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }


    }
}
