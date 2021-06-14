using System;
using System.Numerics;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = 1;

            for(int i = 100; i > 0; i--)
            {
                number *= i;
            }

            int sum = 0;
            while(number > 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            Console.WriteLine(sum);

        }
    }
}
