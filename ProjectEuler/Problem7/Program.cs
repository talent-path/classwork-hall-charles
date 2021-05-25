using System;
using Utils;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for(int i = 0; i < int.MaxValue && count <= 10001; i++)
            {
                if(Util.IsPrime(i))
                {
                    count++;
                    if (count == 10002)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
