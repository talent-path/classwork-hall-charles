using System;
using System.IO;

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = null;
            int[,] grid = new int[20, 20];
            int rowIndex = 0;

            using (StreamReader reader = new StreamReader("../../../grid.txt"))
            {
                while((line = reader.ReadLine()) != null)
                {
                    string[] lineNumbers = line.Split(" ");

                    for(int i = 0; i < lineNumbers.Length; i++)
                    {
                        grid[rowIndex, i] = int.Parse(lineNumbers[i]);
                    }

                    rowIndex++;
                }
                Console.WriteLine(ProductOfFour(grid));
            }
        }

        static int ProductOfFour(int [,] arr)
        {
            int maxToReturn = 0;

            int a, b, c, d;

            for(int i = 0; i < 17; i++)
            {
                for(int j = 0; j < 17; j++)
                {
                    a = arr[i, j];
                    b = arr[i, j + 1];
                    c = arr[i, j + 2];
                    d = arr[i, j + 3];

                    int horizontalProduct = a * b * c * d;

                    a = arr[i, j];
                    b = arr[i + 1, j];
                    c = arr[i + 2, j];
                    d = arr[i + 3, j];

                    int verticalProduct = a * b * c * d;

                    int leftDiagonal = 0;

                    if(j >= 3)
                    {
                        a = arr[i, j];
                        b = arr[i + 1, j - 1];
                        c = arr[i + 2, j - 2];
                        d = arr[i + 3, j - 3];
                        leftDiagonal = a * b * c * d;
                    }

                    a = arr[i, j];
                    b = arr[i + 1, j + 1];
                    c = arr[i + 2, j + 2];
                    d = arr[i + 3, j + 3];
                    int rightDiagonal = a * b * c * d;

                    maxToReturn = Math.Max(maxToReturn, Math.Max(Math.Max(horizontalProduct,verticalProduct),Math.Max(leftDiagonal,rightDiagonal)));
                }
            }

            return maxToReturn;
        }
    }
}
