namespace BlindMansBuff
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            const int COUNT_OPONENTS = 3;
            int[] sizeMayrix = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[sizeMayrix[0], sizeMayrix[1]];
            int startRow = -1;
            int startCow = -1;
            int moves = 0;
            int touchedOpponent = 0;
            

            for (int row = 0; row < sizeMayrix[0]; row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int cow = 0; cow < sizeMayrix[1]; cow++)
                {
                    if (input[cow] == 'B')
                    {
                        startRow = row;
                        startCow = cow;
                    }
                    matrix[row, cow] = input[cow];
                }
            }
            string comand;
            while ((comand = Console.ReadLine()) != "Finish")
            {
                int row = startRow; int cow = startCow;
                switch (comand)
                {
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                    case "right":
                        cow++;
                        break;
                    case "left":
                        cow--;
                        break;
                }
                if (!CheckIndexMatrix(matrix, row, cow))
                {
                    continue;
                }
                if (matrix[row, cow] == 'O')
                {
                    continue;
                }
                moves++;
                matrix[startRow, startCow] = '-';
                if (matrix[row, cow] == '-')
                {
                    matrix[row, cow] = 'B';
                    startCow = cow;
                    startRow = row;
                }
                else if (matrix[row, cow] == 'P')
                {
                    matrix[row, cow] = 'B';
                    touchedOpponent++;
                    if(touchedOpponent == COUNT_OPONENTS)
                    {
                        break;
                    }
                    startCow = cow;
                    startRow = row;
                }


            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponent} Moves made: {moves}");

        }

        static bool CheckIndexMatrix(char[,] matrix, int row, int cow)
        {
            if (row < 0 || cow < 0 || row >= matrix.GetLength(0) || cow >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
