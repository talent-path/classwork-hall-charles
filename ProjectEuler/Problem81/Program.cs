using System;
using System.IO;

namespace Problem81
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../p081_matrix.txt"))
            {
                int[,] grid = new int[80,80];
                string line = null;
                int r = 0;
                while((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(',');
                    for(int i = 0; i < numbers.Length; i++)
                    {
                        grid[r, i] = int.Parse(numbers[i]);
                    }
                    r++;
                }

                int sum = grid[79,79];
                for(int row = 79; row > 0; row--)
                {
                    for(int col = 79; col > 0; col--)
                    {
                        sum += Math.Min(grid[row - 1, col], grid[row, col - 1]);
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
