using System;
using System.Collections.Generic;
using LinkedList;
using GenericHeap;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> firstHeap = new MaxHeap<int>();

            //Add works as expected
            firstHeap.Add(3);
            firstHeap.Add(4);
            firstHeap.Add(5);
            firstHeap.Add(6);
            firstHeap.Add(1);
            firstHeap.Add(2);

            //Remove
            //firstHeap.Remove(2);

            Console.WriteLine(firstHeap.Peek());

            //Pop works as expected
            //Console.WriteLine(firstHeap.Peek());

            //firstHeap.Pop();

            //Console.WriteLine(firstHeap.Peek());

            //firstHeap.Pop();

            //Console.WriteLine(firstHeap.Peek());

            //firstHeap.Pop();

            //Console.WriteLine(firstHeap.Peek());

        }
    }
}
