using System;
using System.Collections.Generic;
using Utils;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLength = 0;

            List<int> bPrimes = new List<int>();
            (int, int) coefficients = (0, 0);

            for (int i = 2; i <= 1000; i++)
            {
                if (Util.IsPrime(i))
                {
                    bPrimes.Add(i);
                }
            }

            foreach (int b in bPrimes)
            {
                for (int a = -999; a <= 999; a++)
                {
                    bool foundNonPrime = false;

                    int n = 0;

                    int count = 0;

                    while (!foundNonPrime)
                    {
                        if (Util.IsPrime(n * n + a * n + b))
                        {
                            count++;
                        }
                        else
                        {
                            foundNonPrime = true;
                        }
                        n++;
                    }

                    if (count > maxLength)
                    {
                        coefficients = (a, b);
                        maxLength = count;
                    }
                }
            }

            Console.WriteLine(coefficients.Item1 * coefficients.Item2);
        }
    }
}
