using System;
using System.Collections.Generic;
using Utils;

namespace Problem37
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int i = 10;
            int sum = 0;

            while(count < 11)
            {
               if(RightToLeft(i) && LeftToRight(i))
                {
                    sum += i;
                    count++;
                }

                i++;
            }

            Console.WriteLine(sum);
        }

        public static bool RightToLeft(int num)
        {
            bool truncatable = Util.IsPrime(num);
            if (!truncatable) return truncatable;

            string parsedNum = num.ToString();

            while(parsedNum.Length > 1)
            {
                parsedNum = parsedNum.Remove(parsedNum.Length - 1);
                int newNum = int.Parse(parsedNum);
                
                truncatable = Util.IsPrime(newNum);
                if (!truncatable) break;
            }

            return truncatable;
        }

        public static bool LeftToRight(int num)
        {
            bool truncatable = Util.IsPrime(num);
            if (!truncatable) return truncatable;

            string word = num.ToString();
            while (word.Length > 1)
            {
                word = word.Substring(1, word.Length - 1);
                int piece = int.Parse(word);

                truncatable = Util.IsPrime(piece);
                if (!truncatable) break;
            }

            return truncatable;
        }
    }
}
