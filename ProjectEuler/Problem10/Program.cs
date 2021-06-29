using System;
using Utils;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 2;

            for(int i = 3; i < 2000000; i+=2)
            {
                if (Util.IsPrime(i))
                    sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}
