using System;
using System.Collections.Generic;
using System.IO;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            string problem67 = "../../../p067_triangle.txt";
            string problem18 = "../../../Problem18.txt";
            using (StreamReader reader = new StreamReader(problem67))
            {
                List<List<int>> pyramid = new List<List<int>>();
                string data;
                while ((data = reader.ReadLine()) != null)
                {
                    string[] arr = data.Split(' ');
                    List<int> row = new List<int>();

                    foreach (string num in arr)
                    {
                        int newNum = int.Parse(num);
                        row.Add(newNum);
                    }

                    pyramid.Add(row);
                }

                for(int i = 1; i < pyramid.Count; i++)
                {
                    int sum = 0;
                    for(int j = 0; j < pyramid[i].Count; j++)
                    {
                        if(j == 0)
                        {
                            sum = pyramid[i][j] + pyramid[i - 1][j];
                        }
                        else if(j == pyramid[i].Count - 1)
                        {
                            sum = pyramid[i][j] + pyramid[i - 1][j - 1];
                        }
                        else
                        {
                            sum = pyramid[i][j] + Math.Max(pyramid[i - 1][j], pyramid[i - 1][j - 1]);
                        }

                        pyramid[i][j] = sum;
                    }
                }

                int maxSum = 0;
                int lastRow = pyramid.Count - 1;

                for(int i = 0; i < pyramid[lastRow].Count; i++)
                {
                }

            }
        }
    }
}
