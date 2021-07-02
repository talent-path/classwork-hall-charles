using System;
using System.Collections.Generic;
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
        public static bool IsPrime(int num)
        {
            if (num < 2)
                return false;

            bool prime = true;

            int squareRoot = GetSquareRoot(num);

            if(num % 2 == 0)
            {
                return num == 2;
            }

            for(int i = 3; i <= squareRoot; i+=2)
            {
                if(num % i == 0)
                {
                    prime = false;
                    break;
                }
            }

            return prime;
        }

        public static bool IntIsPrime(int num)
        {
            if (num < 2)
                return false;
            int root = GetSquareRoot(num);
            if (num % 2 == 0 && num != 2)
                return false;
            for (int i = 3; i <= root; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
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

        public static int GetSquareRoot(int num)
        {
            int squareRoot = 0;

            for (int i = 1; i < num; i++)
            {
                if ((i * i) > num)
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

        public static long GetFactors(long num)
        {
            long count = 0;
            for(long i = 1; i * i <= num; i++)
            {
                if(num % i == 0)
                {
                    count++;
                    if(i * i != num)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static void GeneratePermutations
            (List<string> allPermutations, string currNum, List<string> availableNums)
        {
            if (availableNums.Count == 0)
            {
                if(int.Parse(currNum) % 2 != 0)
                allPermutations.Add(currNum);
            }
            else
            {
                for (int i = 0; i < availableNums.Count; i++)
                {
                    string addString = availableNums[i];

                    availableNums.RemoveAt(i);

                    GeneratePermutations(allPermutations, currNum + addString, availableNums);

                    availableNums.Insert(i, addString);
                }
            }
        }
    }
}
