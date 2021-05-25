using System;
using System.Numerics;

namespace BigRational
{
    class Program
    {
        static void Main(string[] args)
        {
            BigRational twoThirds = new BigRational(2, 3);
            BigRational threeFourths = new BigRational(3, 4);
            BigRational oneHalf = new BigRational(1, 2);
            BigRational threeSixths = new BigRational(3, 6);

            Console.WriteLine("Less than");
            Console.WriteLine(twoThirds < threeFourths);//True
            Console.WriteLine(threeFourths < twoThirds);//False
            Console.WriteLine("----------------");

            Console.WriteLine("Greater than");
            Console.WriteLine(twoThirds > threeFourths);//False
            Console.WriteLine(threeFourths > twoThirds);//True
            Console.WriteLine("----------------");

            Console.WriteLine("Greater than or equals");
            Console.WriteLine(threeFourths >= twoThirds);//True
            Console.WriteLine(threeFourths >= threeFourths);//True
            Console.WriteLine(twoThirds >= threeFourths);//False
            Console.WriteLine("----------------");

            Console.WriteLine("Less than or equals");
            Console.WriteLine(threeFourths <= twoThirds);//False
            Console.WriteLine(threeFourths <= threeFourths);//True
            Console.WriteLine(twoThirds <= threeFourths);//True
            Console.WriteLine("----------------");

            Console.WriteLine("Equals");
            Console.WriteLine(threeFourths == twoThirds);//False
            Console.WriteLine(threeFourths == threeFourths);//True
            Console.WriteLine(oneHalf == threeSixths);//True
            Console.WriteLine("----------------");

            Console.WriteLine("Not Equals");
            Console.WriteLine(threeFourths != twoThirds);//True
            Console.WriteLine(threeFourths != threeFourths);//False
            Console.WriteLine(oneHalf != threeSixths);//False
            Console.WriteLine("----------------");

        }
    }
}
