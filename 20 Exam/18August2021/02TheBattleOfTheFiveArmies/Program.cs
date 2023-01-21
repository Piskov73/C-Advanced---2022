using System;
using System.Collections.Generic;
using System.Linq;

namespace _02TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int line = int.Parse(Console.ReadLine());
            char[][] area = new char[line][];
            int startRow = 0;
            int startCol = 0;
            bool victory = false;

            for (int row = 0; row < line; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                if (input.Contains('A'))
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'A')
                        {
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
                area[row] = input;

            }

            area[startRow][startCol] = '-';

            while (true)
            {
                int row = startRow;
                int col = startCol;

                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                area[int.Parse(comand[1])][int.Parse(comand[2])] = 'O';
                switch (comand[0])
                {
                    //o	It can be “up”, “down”, “left”, “right”
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
                armor--;

                if (!CheckMatrixIndex(area, row, col))
                {
                    if (armor <= 0)
                    {
                        break;
                    }
                    continue;
                }
                if (area[row][col] == 'M')
                {
                    area[row][col] = '-';
                    victory= true;
                    break;
                }
                if (armor <= 0)
                {
                    startRow= row; startCol = col;
                    break;
                }
                if (area[row][col] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        startRow = row; startCol = col;
                        break;
                    }
                  

                }
                area[row][col] = '-';
                startRow = row; startCol = col;

            }

            if(victory)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else
            {
                area[startRow][startCol] = 'X';
                Console.WriteLine($"The army was defeated at {startRow};{startCol}.");
            }

            PrinJaggedArays(area);
        }



        static void PrinJaggedArays(char[][] area)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", area[i].ToArray()));
            }
        }

        static bool CheckMatrixIndex(char[][] area, int row, int col)
        {
            if(row<0 || col < 0 || row >= area.Length|| col >= area[row].Length)
            {
                return false;
            }
                 
            return true;
        }
    }
}
