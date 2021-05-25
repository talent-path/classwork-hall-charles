using System;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
            for (int i = 1; i < int.MaxValue; i++)
            {
                bool flag = true;
                for (int j = 20; j > 10; j--)
                {
                    if (i % j != 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}

