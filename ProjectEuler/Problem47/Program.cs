using System;
using System.Collections.Generic;
using Utils;

namespace Problem47
{
    class Program
    {
        //The first two consecutive numbers to have two distinct prime factors are:
        //14 = 2 × 7
        //15 = 3 × 5
        //The first three consecutive numbers to have three distinct prime factors are:
        //644 = 2² × 7 × 23
        //645 = 3 × 5 × 43
        //646 = 2 × 17 × 19.
        //Find the first four consecutive integers to have four distinct prime factors each.What is the first of these numbers?
        static void Main(string[] args)
        {
            int count = 0;
            Dictionary<int, HashSet<int>> primeFactors = new Dictionary<int, HashSet<int>>();
            HashSet<int> primeNumbers = new HashSet<int>();
            int number = 3;
            while (count < 4)
            {
                primeNumbers = GeneratePrimeFactors(number);
                primeFactors.Add(number, primeNumbers);
                if (primeFactors[number].Count == 4)
                    count++;
                else
                    count = 0;
                number++;
            }
            Console.WriteLine(number - 4);
        }
        public static HashSet<int> GeneratePrimeFactors(int num)
        {
            HashSet<int> primeFactors = new HashSet<int>();
            for (int i = 1; i <= num / 2; ++i)
            {
                if (num % i == 0 && Util.IntIsPrime(i))
                {
                    primeFactors.Add(i);
                }
            }
            return primeFactors;
        }
    }
}
