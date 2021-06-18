using System;
using System.Collections.Generic;

namespace Problem43
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> allNums = new List<long>();
            List<string> availableNums = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            string perm = "";

            long sum = 0;
            GeneratePermutations(allNums, perm, availableNums);

            foreach(long num in allNums)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }

        public static void GeneratePermutations
            (List<long> allNums, string currNum, List<string> availableNums)
        {
            if (availableNums.Count == 0)
            {
                //Perform check here
                if (DivisibilityCheck(currNum))
                {
                    allNums.Add(Int64.Parse(currNum));
                }
            }
            else
            {
                for (int i = 0; i < availableNums.Count; i++)
                {
                    string addString = availableNums[i];

                    availableNums.RemoveAt(i);

                    GeneratePermutations(allNums, currNum + addString, availableNums);

                    availableNums.Insert(i, addString);
                }
            }
        }

        public static bool DivisibilityCheck(string num)
        {
            //replace with for loop?
            int firstSet = int.Parse(num.Substring(1, 3));
            int secSet = int.Parse(num.Substring(2 , 3));
            int thirdSet = int.Parse(num.Substring(3, 3));
            int fourthSet = int.Parse(num.Substring(4, 3));
            int fifthSet = int.Parse(num.Substring(5, 3));
            int sixthSet = int.Parse(num.Substring(6, 3));
            int seventhSet = int.Parse(num.Substring(7, 3));

            if((firstSet % 2 == 0) && (secSet % 3 == 0) && (thirdSet % 5 == 0) &&
               (fourthSet % 7 == 0) && (fifthSet % 11 == 0) && (sixthSet % 13 == 0)
               && (seventhSet % 17 == 0))
            {
                return true;
            }

            return false;
        }
    }
}
