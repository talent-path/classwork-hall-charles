using System;
using Utils;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find the largest palindrome made from the product of two 3-digit numbers.
            int max = int.MinValue;
            for (int i = 999; i > 100; i--)
            {
                for(int j = 999; j > 100; j--)
                {
                    if(Util.IsPalindrome(i * j) && (i * j) > max)
                    {
                        max = i * j;
                        break;
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
