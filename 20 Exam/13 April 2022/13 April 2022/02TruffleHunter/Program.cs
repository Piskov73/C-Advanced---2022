using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace _02TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            // •Black truffle -'B'
            //•	Summer truffle -'S'
            //•	White truffle -'W'
            int truffleBlack = 0;
            int truffleSummer = 0;
            int truffleWhite = 0;
            int wildBoar = 0;


            string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (comand[0] != "Stop")
            {
                int row = int.Parse(comand[1]);
                int col = int.Parse(comand[2]);
                int count = 0;
                switch (comand[0])
                {
                    case "Collect":
                        if (matrix[row, col] == 'B')
                        {
                            truffleBlack++;
                            matrix[row, col] = '-';
                        }
                        else if(matrix[row, col] == 'S')
                        {
                            truffleSummer++;
                            matrix[row, col] = '-';
                        }
                        else if (matrix[row, col] == 'W')
                        {
                            truffleWhite++;
                            matrix[row, col] = '-';
                        }
                        break;

                    case "Wild_Boar":
                        string direction = comand[3];
                        //o	"up", "down", "left", and "right"

                        switch (direction)
                        {
                            case "up":
                                for (int i = row; i >= 0; i--)
                                {
                                    if(count%2 == 0)
                                    {
                                        if (matrix[i,col]=='B'|| matrix[i, col] =='S'|| matrix[i, col] == 'W')
                                        {
                                            matrix[i, col] = '-';
                                            wildBoar++;
                                        }
                                    }
                                    count++;
                                }
                                break;
                            case "down":
                                for (int i = row; i < n; i++)
                                {
                                    if (count % 2 == 0)
                                    {
                                        if (matrix[i, col] == 'B' || matrix[i, col] == 'S' || matrix[i, col] == 'W')
                                        {
                                            matrix[i, col] = '-';
                                            wildBoar++;
                                        }
                                    }
                                    count++;
                                }

                                break;
                            case "left":
                                for (int i = col; i >= 0; i--)
                                {
                                    if (count % 2 == 0)
                                    {
                                        if (matrix[row, i] == 'B' || matrix[row, i] == 'S' || matrix[row, i] == 'W')
                                        {
                                            matrix[row, i] = '-';
                                            wildBoar++;
                                        }
                                    }
                                    count++;
                                }
                                break;

                            default:
                                for (int i = col; i < n; i++)
                                {
                                    if (count % 2 == 0)
                                    {
                                        if (matrix[row, i] == 'B' || matrix[row, i] == 'S' || matrix[row, i] == 'W')
                                        {
                                            matrix[row, i] = '-';
                                            wildBoar++;
                                        }
                                    }
                                    count++;
                                }
                                break;
                        }

                        break;
                }

                comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Peter manages to harvest {truffleBlack} black, {truffleSummer} summer, and {truffleWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoar} truffles.");
            
            
            PrintCharMatrix(matrix);
        }
        static void PrintCharMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
