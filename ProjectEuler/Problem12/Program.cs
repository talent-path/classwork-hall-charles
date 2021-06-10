using System;
using Utils;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterate = 0;
            int increase = 1;

            bool solved = false;

            while(!solved)
            {
                iterate += increase;
                increase++;
                if(Util.GetFactors(iterate) >= 500)
                {
                    solved = true;
                }
            }

            Console.WriteLine(iterate);

        }
    }
}
