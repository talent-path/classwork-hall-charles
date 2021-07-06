using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problem59
{
    //exp is key
    //An extract taken from the introduction of one of Euler's most celebrated papers, "De summis serierum reciprocarum"
    //[On the sums of series of reciprocals]: I have recently found, quite unexpectedly, an elegant expression for the entire sum of this series
    //1 + 1/4 + 1/9 + 1/16 + etc., which depends on the quadrature of the circle, so that if the true sum of this series is obtained,
    //from it at once the quadrature of the circle follows. Namely, I have found that the sum of this series is a sixth part of the square of the
    //perimeter of the circle whose diameter is 1; or by putting the sum of this series equal to s, it has the ratio sqrt(6)
    //multiplied by s to 1 of the perimeter to the diameter. I will soon show that the sum of this series to be approximately 1.644934066842264364;
    //and from multiplying this number by six, and then taking the square root, the number 3.141592653589793238 is indeed produced, which expresses
    //the perimeter of a circle whose diameter is 1. Following again the same steps by which I had arrived at this sum, I have discovered that the
    //sum of the series 1 + 1/16 + 1/81 + 1/256 + 1/625 + etc. also depends on the quadrature of the circle. Namely, the sum of this multiplied by
    //90 gives the biquadrate (fourth power) of the circumference of the perimeter of a circle whose diameter is 1. And by similar reasoning I have
    //likewise been able to determine the sums of the subsequent series in which the exponents are even numbers.
    class Program
    {
        static void Main(string[] args)
        {
            string text = "An extract taken from the introduction of one of Euler's most celebrated papers, \"De summis serierum reciprocarum\" [On the sums of series of reciprocals]: I have recently found, quite unexpectedly, an elegant expression for the entire sum of this series 1 + 1/4 + 1/9 + 1/16 + etc., which depends on the quadrature of the circle, so that if the true sum of this series is obtained, from it at once the quadrature of the circle follows. Namely, I have found that the sum of this series is a sixth part of the square of the perimeter of the circle whose diameter is 1; or by putting the sum of this series equal to s, it has the ratio sqrt(6) multiplied by s to 1 of the perimeter to the diameter. I will soon show that the sum of this series to be approximately 1.644934066842264364; and from multiplying this number by six, and then taking the square root, the number 3.141592653589793238 is indeed produced, which expresses the perimeter of a circle whose diameter is 1. Following again the same steps by which I had arrived at this sum, I have discovered that the sum of the series 1 + 1/16 + 1/81 + 1/256 + 1/625 + etc. also depends on the quadrature of the circle. Namely, the sum of this multiplied by 90 gives the biquadrate (fourth power) of the circumference of the perimeter of a circle whose diameter is 1. And by similar reasoning I have likewise been able to determine the sums of the subsequent series in which the exponents are even numbers.";
            int sum = 0;
            byte[] ASCIIvalues = Encoding.ASCII.GetBytes(text);
            foreach (var value in ASCIIvalues)
            {
                sum += value;
            }

            Console.WriteLine(sum);

            using (StreamReader reader = new StreamReader("../../../p059_cipher.txt"))
            {
                string line = reader.ReadLine();
                var asciiValues = line.Split(',');

                //Generate all key possibilities
                for(int i = 97; i < 123; i++)
                {
                    for(int j = 97; j < 123; j++)
                    {
                        for(int k = 97; k < 123; k++)
                        {
                            int count = 0;
                            string stringDecoded = "";
                            bool valid = true;
                            while(count < asciiValues.Length)
                            {
                                //XOR first num with first char in key
                                if(count++ < asciiValues.Length)
                                {
                                    int value = i ^ int.Parse(asciiValues[count - 1]);
                                    if (value > 31 && value < 127)
                                    {
                                        stringDecoded += Convert.ToChar(value);
                                    }
                                    else
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                                //XOR sec num with sec char in key
                                if(count++ < asciiValues.Length)
                                {
                                    int value = j ^ int.Parse(asciiValues[count - 1]);
                                    if (value > 31 && value < 127)
                                    {
                                        stringDecoded += Convert.ToChar(value);
                                    }
                                    else
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                                //XOR third num with third char in key
                                if (count++ < asciiValues.Length)
                                {
                                    int value = k ^ int.Parse(asciiValues[count - 1]);
                                    if (value > 31 && value < 127)
                                    {
                                        stringDecoded += Convert.ToChar(value);
                                    }
                                    else
                                    {
                                        valid = false;
                                        break;
                                    }
                                }
                            }

                            if (valid)
                            {
                                Console.WriteLine(Convert.ToChar(i) + " " + Convert.ToChar(j) + " " + Convert.ToChar(k));
                                Console.WriteLine(stringDecoded);
                            }
                        }
                    }
                }

            }
        }
    }
}
