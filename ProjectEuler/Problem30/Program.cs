using System;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int curSum = 0;

            for(int cur = 10; cur < 999999; cur++)
            {
                curSum = 0;
                int copy = cur;
                while(copy != 0)
                {
                    int d = copy % 10;
                    int fifth = d * d * d * d * d;
                    curSum += fifth;
                    copy /= 10;
                }

                if (curSum == cur)
                {
                    sum += curSum;
                }

            }

            Console.WriteLine(sum);

        }
    }
}
