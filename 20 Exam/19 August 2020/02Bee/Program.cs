using System;

namespace _02Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size =int.Parse(Console.ReadLine());
            char[,] territory=new char[size,size];
            territory = CharMatrix(territory);
            
            int[] index = GetStartIndex(territory, 'B');

            int startRow = index[0];
            int startCol = index[1];
            int polinationedFlowers = 0;
            bool fall=false;
            string comand=Console.ReadLine();
            while (comand != "End") 
            {
                territory[startRow, startCol] = '.';

                int row = startRow;
                int col = startCol;
                index=GetMovement(comand, row, col);
                row = index[0];
                col = index[1];
                if(CheckingMatrix(row, col, territory))
                {
                    if (territory[row, col] == 'f')
                    {
                        territory[row, col] = 'B';

                        polinationedFlowers++;
                        startRow= row;
                        startCol= col;
                    }
                    else if(territory[row, col] == 'O')
                    {
                        territory[row, col] = '.';
                        index = GetMovement(comand, row, col);
                        row = index[0];
                        col = index[1];
                        if(CheckingMatrix(row,col,territory))
                        {
                            if (territory[row, col] == 'f')
                            {
                                territory[row, col] = 'B';

                                polinationedFlowers++;
                                startRow = row;
                                startCol = col;
                            }
                            else
                            {
                                territory[row, col] = 'B';

                                startRow = row;
                                startCol = col;
                            }
                        }
                        else
                        {
                            fall = true;
                            break;
                        }
                    }
                    else
                    {
                        territory[row, col] = 'B';

                        startRow = row;
                        startCol = col;
                    }
                }
                else
                {
                    fall= true;
                    break;
                }
                comand = Console.ReadLine();
            }

            if (fall)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (polinationedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-polinationedFlowers} flowers more");
            }


            PrintCharMatrix(territory);

        }
        static char[,] CharMatrix(char[,] matrix)
        {
            char[,] charMatrix=new char[matrix.GetLength(0),matrix.GetLength(1)];

            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                string input=Console.ReadLine();
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
            int startRow=-1; int startCol=-1;
            bool stop=false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ch)
                    {
                        startRow=row;
                        startCol=col;
                        stop=true;
                        break;
                    }
                }
                if(stop)
                {
                    break;
                }
            }
            int[] index=new int[] {startRow,startCol};
            return index;
        }

        static int[] GetMovement(string comand,int row,int col)
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
            return new int[] {row,col};
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
