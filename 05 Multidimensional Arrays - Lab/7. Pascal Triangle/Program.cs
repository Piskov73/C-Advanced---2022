using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] triangle = new long[n][];
            int count = 1;

            for (int row = 0; row < n; row++)
            {
                triangle[row] = new long[count];
                triangle[row][0] = 1;
                triangle[row][count - 1] = 1;
                if (triangle[row].Length > 2)
                {
                    for (int col = 1; col < triangle[row].Length - 1; col++)
                    {
                        triangle[row][col] = triangle[row - 1][col] + triangle[row - 1][col - 1];
                    }
                }
                count++;
            }
            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}
