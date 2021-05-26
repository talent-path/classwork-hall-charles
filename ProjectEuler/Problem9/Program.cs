using System;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            //There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
            int product = 0;

            for(int a = 1; a < 1000; a++)
            {
                for(int b = 1; b < 1000; b++)
                {
                    int c = 1000 - (a + b);
                    if((a * a) + (b * b) == (c * c))
                    {
                        product = a * b * c;
                    }
                }
            }

            Console.WriteLine(product);
        }
    }
}
