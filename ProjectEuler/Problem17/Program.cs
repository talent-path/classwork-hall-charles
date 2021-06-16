using System;

namespace Problem17
{
    class Program
    {
        //If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        //If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        static void Main(string[] args)
        {
            string[] ones = { "","one","two","three","four","five","six","seven","eight","nine"};
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            int letterCount = 0;

            for(int i = 1; i <= 1000; i++)
            {
                if(i < 10)
                {
                    letterCount += ones[i].Length;
                }
                else if(i <= 19)
                {
                    letterCount += teens[i - 10].Length;
                }
                else if(i < 100)
                {
                    int tensDigit = i / 10;
                    int onesDigit = i % 10;

                    letterCount += tens[tensDigit - 2].Length + ones[onesDigit].Length;
                }
                else if(i < 1000)
                {
                    int hundredsDigit = i / 100;
                    int tensDigit = (i % 100);
                    int onesDigit = (i % 100) % 10;

                    if (tensDigit >= 10 && tensDigit <= 19)
                    {
                        tensDigit -= 10;
                        letterCount += teens[tensDigit].Length;
                        onesDigit = 0;
                    }
                    else if(tensDigit > 19)
                    {
                        tensDigit /= 10;//-2
                        letterCount += tens[tensDigit - 2].Length;
                    }

                    if (i % 100 == 0)
                    {
                        letterCount += ones[hundredsDigit].Length + 7 + ones[onesDigit].Length;
                    }
                    else
                    {
                        letterCount += ones[hundredsDigit].Length + 7 + 3 + ones[onesDigit].Length;
                    }

                }

                if (i == 1000)
                {
                    //Add 1000
                    letterCount += 11;
                }
            }
            Console.WriteLine(letterCount);
        }
    }
}
