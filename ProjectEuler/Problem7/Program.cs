using System;
using Utils;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            for(int i = 3; i < int.MaxValue && count <= 10001; i+=2)
            {
                if(Util.IsPrime(i))
                {
                    count++;
                    if (count == 10001)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
