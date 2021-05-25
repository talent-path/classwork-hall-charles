using System;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrime(BigInteger num)
        {
            bool prime = true;

            //Number is prime if..
            //1 2 3 4 6 12
            //1 12
            //2 6
            //3 4

            BigInteger squareRoot = GetSquareRoot(num);

            //Handle 2 special case
            if(num % 2 == 0)
            {
                return num == 2;
            }

            for(BigInteger i = 3; i <= squareRoot; i+=2)
            {
                if(num % i == 0)
                {
                    prime = false;
                    break;
                }
            }

            return prime;
        }

        public static BigInteger GetSquareRoot(BigInteger num)
        {
            BigInteger squareRoot = 0;

            for(BigInteger i = 1; i < num; i++)
            {
               if((i*i) > num)
               {
                    squareRoot = i - 1;
                    break;
               }
            }

            return squareRoot;
        }
    }
}
