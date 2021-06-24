using System;
using System.Collections.Generic;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxDenom = 2;
            int maxCycle = 0;
            for(int denom = 2; denom < 1000; denom++)
            {
                HashSet<int> remainders = new HashSet<int>();

                int remainder = 1;
                while (remainder != 0)
                {
                    int value = remainder / denom;
                    remainder = (remainder - (denom * value)) * 10;
                    if (!remainders.Add(remainder))
                    {
                        if(remainders.Count > maxCycle)
                        {
                            maxDenom = denom;
                            maxCycle = remainders.Count;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Max denom is " + maxDenom + " with a cycle length of " + maxCycle);
        }


    }
}
