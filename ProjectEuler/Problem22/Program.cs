using System;
using System.Collections.Generic;
using System.IO;

namespace Problem22
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../names.txt"))
            {
                int scoreSum = 0;
                List<string> names = new List<string>();

                string text = reader.ReadToEnd();
                string[] arr = text.Split(',');

                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr[i].Replace("\"", "");
                    names.Add(arr[i]);
                }

                names.Sort();

                for(int i = 0; i < names.Count; i++)
                {
                    char[] letters = names[i].ToCharArray();
                    int nameScore = GetScore(letters);
                    scoreSum += ((i+1) * nameScore);
                }

                Console.WriteLine("Sum");
                Console.WriteLine(scoreSum);
            }
        }

        private static int GetScore(char[] letters)
        {
            int wordSum = 0;

            foreach(char c in letters)
            {
                wordSum += char.ToUpper(c) - 64;
            }

            return wordSum;
        }
    }
}
