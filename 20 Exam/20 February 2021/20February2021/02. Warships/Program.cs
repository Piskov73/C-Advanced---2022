using System;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] comand = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];

            int shipPlayrOne = 0;
            int shipPlayrTwo = 0;
            int count = 0;


            for (int row = 0; row < size; row++)
            {


                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    if (input[col] == '<')
                    {
                        shipPlayrOne++;
                    }
                    if (input[col] == '>')
                    {
                        shipPlayrTwo++;
                    }
                    matrix[row, col] = input[col];
                }
            }

            for (int i = 0; i < comand.Length; i++)
            {
                int[] coordinstes = comand[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinstes[0];
                int col = coordinstes[1];
                if(CheckingMatrix(row,col,matrix))
                {
                    if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        shipPlayrOne--;
                        count++;
                    }
                    if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        shipPlayrTwo--;
                        count++;
                    }
                    if (matrix[row, col] == '#')
                    {
                        matrix[row, col] = 'X';
                       
                        for (int row1 = row-1; row1 <= row+1; row1++)
                        {
                            for (int col1 = col-1; col1 <= col+1; col1++)
                            {
                                if (CheckingMatrix(row1, col1,matrix))
                                {
                                    if (matrix[row1, col1] == '<')
                                    {
                                        matrix[row1, col1] = 'X';
                                        shipPlayrOne--;
                                        count++;
                                    }
                                    if (matrix[row1, col1] == '>')
                                    {
                                        matrix[row1, col1] = 'X';
                                        shipPlayrTwo--;
                                        count++;
                                    }
                                  
                                }
                            }
                           

                        }
                    }
                    if(shipPlayrOne==0||shipPlayrTwo==0)
                    {
                        break;
                    }
                }

            }

            if(shipPlayrOne==0)
            {
                Console.WriteLine($"Player Two has won the game! {count} ships have been sunk in the battle.");
            }
            else if(shipPlayrTwo==0)
            {
                Console.WriteLine($"Player One has won the game! {count} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipPlayrOne} ships left. Player Two has {shipPlayrTwo} ships left.");
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
