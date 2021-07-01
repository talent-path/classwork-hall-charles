using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;

namespace Problem41
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger pandigitalPri = 0;
            List<string> allPermutaions = new List<string>();
            string currNum = "";
            List<string> avaiableNums = new List<string> { "9", "8", "7", "6", "5", "4", "3", "2", "1" };
            bool found = false;
            for (int i = 0; i < 9; i++)
            {
                allPermutaions.Clear();
                Util.GeneratePermutations(allPermutaions, currNum, avaiableNums);
                foreach (string prime in allPermutaions)
                {
                    int primeNum = int.Parse(prime);

                    if (Util.IsPrime(primeNum) && primeNum > pandigitalPri)
                    {
                        pandigitalPri = primeNum;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
                avaiableNums.RemoveAt(0);
            }
            Console.WriteLine(pandigitalPri);
        }
        
    }
}
