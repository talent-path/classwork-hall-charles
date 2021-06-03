using System;
using System.Collections.Generic;

namespace GenericHeap
{

    //what is a heap?
    //heap property - each "node" has 2 children,
    //each child is (less for maxheap/greater for minheap) than the parent
    //  therefore top-most node is largest/smallest, respectively


    //parents & children in an array/list

    //                  0
    //       1                    2
    //    3     4              5    6
    //   7 8   9 X

    // LeftChildIndex( int parentIndex ) => parentIndex * 2 + 1;
    // RightChildIndex( int parentIndex ) => parentIndex * 2 + 2;
    // ParentIndex( int childIndex ) => (childIndex - 1) / 2;


    //https://en.wikipedia.org/wiki/Binary_heap
    public class MinHeap<T> where T : IComparable<T>
    {

        //every incoming object will implement IComparable<T>
        //CompareTo semantics:

        //this.CompareTo( that )
        //  -  this comes "before" that or this < that
        //  0  this == that
        //  +  this comes "after" that or this > that

        List<T> _allElements = new List<T>();

        public void Add(T toAdd)
        {
            _allElements.Add(toAdd);
            HeapSort();
        }

        public void Remove(T toRemove)
        {
            //we're looking for a CompareTo() == 0
            int toRemoveIndex = _allElements.IndexOf(toRemove);

            _allElements[toRemoveIndex] = _allElements[_allElements.Count - 1];
            _allElements.RemoveAt(_allElements.Count - 1);

            HeapSort();
        }

        public T Peek()
        {
            if (_allElements.Count > 0) return _allElements[0];
            return default(T);
        }

        public T Pop()
        {
            T toReturn = default(T);
            if (_allElements.Count > 0) toReturn = _allElements[0];

            //todo: actually remove the top node
            //swap with the last element
            //remove the last element
            //heapify()
            _allElements[0] = _allElements[_allElements.Count - 1];
            _allElements.RemoveAt(_allElements.Count - 1);

            HeapSort();

            return toReturn;
        }

        private void Heapify(int i)
        {   
            int min = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < _allElements.Count && _allElements[left].CompareTo(_allElements[min]) == -1)
            {
                min = left;
            }

            if (right < _allElements.Count && _allElements[right].CompareTo(_allElements[min]) == -1)
            {
                min = right;
            }

            if(min != i)
            {
                T tmp = _allElements[i];
                _allElements[i] = _allElements[min];
                _allElements[min] = tmp;
                Heapify(i);
            }
            
        }

        private void HeapSort()
        {
            for (int i = _allElements.Count / 2 - 1; i >= 0; i--)
                Heapify(i);
            for (int i = _allElements.Count - 1; i >= 0; i--)
            {
                T tmp = _allElements[0];
                _allElements[0] = _allElements[i];
                _allElements[i] = tmp;
                Heapify(i);
            }
        }

    }
}
