using System;
using System.Collections.Generic;

namespace GenericHeap
{
    public class MaxHeap<T> where T : IComparable<T>
    {
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
            int max = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < _allElements.Count && _allElements[left].CompareTo(_allElements[max]) == 1)
            {
                max = left;
            }

            if (right < _allElements.Count && _allElements[right].CompareTo(_allElements[max]) == 1)
            {
                max = right;
            }

            if (max != i)
            {
                T tmp = _allElements[i];
                _allElements[i] = _allElements[max];
                _allElements[max] = tmp;
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
