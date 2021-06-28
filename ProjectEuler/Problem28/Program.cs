using System;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 1;
            long number = 1001;
            int numToAdd = 2;
            int count = 0;
            for (int i = 3; i < number * number + 1; i += numToAdd)
            {
                if (count != 4)
                {
                    sum += i;
                    count++;
                }
                if (count == 4)
                {
                    //moving to the next spiral 
                    numToAdd += 2;
                    count = 0;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
