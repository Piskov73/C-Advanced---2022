using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowArea = int.Parse(Console.ReadLine());
            char[][] area = new char[rowArea][];
            for (int i = 0; i < rowArea; i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                area[i] = input;
            }
            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;

            string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "Gong")
            {
                int row = int.Parse(comand[1]);
                int col = int.Parse(comand[2]);

                if (comand[0] == "Find")
                {
                    if (CeckIndex(area, row, col) && area[row][col]=='T')
                    {
                        area[row][col] = '-';
                        countOfCollected++;
                    }
                }
                else
                {
                    if (CeckIndex(area, row, col))
                    {
                        string direction = comand[3];

                        int step = 0;
                        switch (direction)
                        {

                            case "up":
                                for (int i = row; i >= 0; i--)
                                {
                                    if (col >= area[i].Length)
                                    {
                                        col= area[i].Length-1;
                                    }
                                    if (area[i][col] == 'T')
                                    {
                                        countOfOpponentsTokens++;
                                        area[i][col] = '-';
                                    }
                                    step++;
                                    if (step > 3) break;
                                }
                                break;
                            case "down":
                                for (int i = row; i < area.Length; i++)
                                {
                                    if (col >= area[i].Length)
                                    {
                                        col = area[i].Length - 1;
                                    }
                                    if (area[i][col] == 'T')
                                    {
                                        countOfOpponentsTokens++;
                                        area[i][col] = '-';
                                    }
                                    step++;
                                    if (step > 3) break;
                                }
                                break;
                            case "left":
                                for (int i = col; i>=0; i--)
                                {
                                    if (area[row][i] == 'T')
                                    {
                                        countOfOpponentsTokens++;
                                        area[row][i] ='-';
                                    }
                                    step++;
                                    if (step>  3) break;
                                }
                                break;
                            case "right":
                                for (int i = col; i < area[row].Length; i++)
                                {
                                    if (area[row][i] == 'T')
                                    {
                                        countOfOpponentsTokens++;
                                        area[row][i] = '-';
                                    }
                                    step++;
                                    if (step > 3) break;
                                }
                                break;
                        }
                    }
                   
                }

                comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintArea(area);
            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }



        static void PrintArea(char[][] area)
        {
            for (int i = 0; i < area.Length; i++)
            {
                Console.WriteLine(string.Join(" ", area[i]));
            }
        }

        static bool CeckIndex(char[][] area, int row, int col)
        {
            if (row < 0 || col < 0 || row >= area.Length || col >= area[row].Length) return false;  
            return true;

        }
    }
}
