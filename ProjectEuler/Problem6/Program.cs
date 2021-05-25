using System;
using Utils;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
            Console.WriteLine(Util.SquareOfSums(100) - Util.SumOfSquares(100));
        }
    }
}
