using System;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = 1;

            for(int i = 1; i <= 1000; i++)
            {
                number *= 2;
            }

            int sum = 0;

            while(number > 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            //string numString = number.ToString();
            //int sum = 0;
            //for(int i = 0; i < numString.Length; i++)
            //{
            //    sum += int.Parse(numString[i].ToString());
            //}

            Console.WriteLine(sum);
        }
    }
}
