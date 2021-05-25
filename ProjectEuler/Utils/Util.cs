using System;
using System.Numerics;

namespace Utils
{
    public static class Util
    {

        /// <summary>
        /// Checks if a given Big Integer is prime.
        /// </summary>
        /// <param name="maxNum">Number to check.</param>
        /// <returns>True if prime, False if not prime.</returns>
        public static bool IsPrime(BigInteger num)
        {
            bool prime = true;

            BigInteger squareRoot = GetSquareRoot(num);

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

        /// <summary>
        /// Gets the square root of a Big Integer.
        /// </summary>
        /// <param name="maxNum">Number to get square root of.</param>
        /// <returns>The square root.</returns>
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

        /// <summary>
        /// Takes an integer and sees if it is a palindrome.
        /// </summary>
        /// <param name="maxNum">Number to check.</param>
        /// <returns>True if palindrome, False if not palindrome.</returns>
        public static bool IsPalindrome(int num)
        {
            bool palindrome = false;

            string strNum = num.ToString();
            int length = strNum.Length;
            string firstHalf = strNum.Substring(0, length / 2);
            string secHalf = strNum.Substring(length / 2);

            char[] arr = secHalf.ToCharArray();
            Array.Reverse(arr);

            secHalf = string.Concat(arr);

            return firstHalf == secHalf;
        }

        /// <summary>
        /// Calculates the sum of squares of the first n numbers.
        /// </summary>
        /// <param name="maxNum">Inclusive upper bound.</param>
        /// <returns>The sum of squares.</returns>
        public static int SumOfSquares(int maxNum)
        {
            int sumOfSquares = 0;

            for(int i = 1; i <= maxNum; i++)
            {
                sumOfSquares += (i * i);
            }

            return sumOfSquares;
        }

        /// <summary>
        /// Calculates the square of sums of the first n numbers.
        /// </summary>
        /// <param name="maxNum">Inclusive upper bound.</param>
        /// <returns>The square of sums.</returns>
        public static int SquareOfSums(int maxNum)
        {
            int squareOfSums = 0;

            for(int i = 1; i <= maxNum; i++)
            {
                squareOfSums += i;
            }

            return squareOfSums * squareOfSums;
        }
    }
}
