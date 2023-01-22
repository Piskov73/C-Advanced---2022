using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeArea = int.Parse(Console.ReadLine());
            int numbComand = int.Parse(Console.ReadLine());
            char[,] area = new char[sizeArea, sizeArea];
            int startRow = -1;
            int startCol = -1;
            bool final = false;
            for (int row = 0; row < sizeArea; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < sizeArea; col++)
                {
                    if (input[col] == 'f')
                    {
                        startCol = col;
                        startRow = row;
                    }
                    area[row, col] = input[col];
                }
            }

            area[startRow, startCol] = '-';

            for (int i = 0; i < numbComand; i++)
            {
                int row = startRow;
                int col = startCol;
                string comand = Console.ReadLine();
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
                //up, down, left or right.
                if (comand == "up" && row < 0)
                {
                    row = sizeArea - 1;
                }
                else if (comand == "down" && row >= sizeArea)
                {
                    row = 0;
                }
                else if(comand== "left" && col < 0)
                {
                    col= sizeArea - 1;
                }
                else if(comand== "right" && col >= sizeArea)
                {
                    col = 0;
                }

                if (area[row, col] == 'F')
                {
                    final= true;
                    startRow= row;
                    startCol= col;
                    break;
                }
                else if (area[row, col] == 'B')
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

                    if (comand == "up" && row < 0)
                    {
                        row = sizeArea - 1;
                    }
                    else if (comand == "down" && row >= sizeArea)
                    {
                        row = 0;
                    }
                    else if (comand == "left" && col < 0)
                    {
                        col = sizeArea - 1;
                    }
                    else if (comand == "right" && col >= sizeArea)
                    {
                        col = 0;
                    }
                    startCol= col;
                    startRow= row;
                }
                else if(area[row, col] == 'T')
                {
                    continue;
                }
                else
                {
                    startRow= row;
                    startCol= col;
                }


            }
            area[startRow, startCol] = 'f';

            if (final)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(area);

        }

        static void PrintMatrix(char[,] area)
        {
            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    Console.Write(area[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
