using System;
using System.Numerics;
using Utils;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            //What is the largest prime factor of the number 600851475143 ?

            BigInteger input = 600851475143;

            BigInteger squareRoot = Util.GetSquareRoot(input);

            BigInteger biggestLowFactor = int.MinValue;

            bool found = false;

            for(BigInteger i = 1; i <= squareRoot; i++)
            {
                if(input % i == 0)
                {
                    BigInteger bigFactor = input / i;

                    if(Util.IsPrime(bigFactor))
                    {
                        Console.WriteLine(bigFactor);
                        found = true;
                        break;
                    }

                    if(Util.IsPrime(i))
                    {
                        biggestLowFactor = i;
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine(biggestLowFactor);
            }
        }
    }
}
