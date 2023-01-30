using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeGarden=Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] garden = new int[sizeGarden[0], sizeGarden[1]];
            garden=ReturnMatrix(garden);

            string comand=Console.ReadLine();
            while(comand!= "Bloom Bloom Plow")
            {
                int[] ints=comand.Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int row = ints[0];
                int col = ints[1];
                if(ChekIndexIntMatrix(garden, row, col))
                {
                    for (int i = 0; i < garden.GetLength(0); i++)
                    {
                        garden[row, i]++;
                    }
                    for (int i = 0; i < garden.GetLength(1); i++)
                    {
                        garden[i, col]++;
                    }
                    garden[row, col]--;

                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                
                



                comand=Console.ReadLine() ;
            }

            PrintIntMatrix(garden);
          
        }

        static int[,] ReturnMatrix(int[,] area)
        {
            int[,] matrix= new int[area.GetLength(0),area.GetLength(1)];
            for (int row = 0; row < area.GetLength(0); row++)
            {
                for (int col = 0; col < area.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
        }
        static void PrintIntMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }

        static bool ChekIndexIntMatrix(int[,] matrix,int row,int col)
        {

            if(row<0 || col<0||row>=matrix.GetLength(0)||col>=matrix.GetLength(1))
                return false;

            return true;
        }
    }
}
