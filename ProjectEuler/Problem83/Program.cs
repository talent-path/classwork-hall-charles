using System;
using System.IO;

namespace Problem83
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../p083_matrix.txt"))
            {
                int[,] grid = new int[80, 80];
                string line = null;
                int r = 0;
                while((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(',');
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        grid[r, i] = int.Parse(numbers[i]);
                    }
                    r++;
                }
                int[,] totalCosts = new int[80,80];
                Console.WriteLine(PathCost(grid, 79, 79, totalCosts));
            }
        }

        static int PathCost(int[,] grid, int row, int col, int[,] totalCosts)
        {
            int minPathCost = 0;

            //Base case?
            if(row == 0 && col == 0)
            {//Not quite sure yet?
                return grid[0, 0];
            }
            else
            {
                int upPathCost = Int32.MaxValue;
                int leftPathCost = Int32.MaxValue;
                //Ask for min distance from node 1 above bottom right
                if (row != 0)
                {
                    upPathCost = PathCost(grid, row - 1, col, totalCosts);
                    //grid[row - 1, col] = upPathCost; memoization part?
                }
                //Ask for min distance from node 1 to the left
                if (col != 0)
                {
                    leftPathCost = PathCost(grid, row, col - 1, totalCosts);
                    //grid[row, col - 1] = leftPathCost; memoization part?
                }

                minPathCost = Math.Min(upPathCost, leftPathCost);
            }

            return minPathCost;
        }
    }
}
