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

            Console.WriteLine("Max Heap:");
            Console.WriteLine(firstHeap.Pop());

            Console.WriteLine(firstHeap.Pop());

            Console.WriteLine(firstHeap.Pop());

            Console.WriteLine(firstHeap.Pop());

            Console.WriteLine(firstHeap.Pop());

            Console.WriteLine(firstHeap.Pop());

            MinHeap<int> secondHeap = new MinHeap<int>();

            secondHeap.Add(3);
            secondHeap.Add(4);
            secondHeap.Add(5);
            secondHeap.Add(6);
            secondHeap.Add(1);
            secondHeap.Add(2);

            Console.WriteLine("Min Heap:");
            Console.WriteLine(secondHeap.Pop());

            Console.WriteLine(secondHeap.Pop());

            Console.WriteLine(secondHeap.Pop());

            Console.WriteLine(secondHeap.Pop());

            Console.WriteLine(secondHeap.Pop());

            Console.WriteLine(secondHeap.Pop());
        }
    }
}
