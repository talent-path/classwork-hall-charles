using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{

    public class DavidLinkedList<T> : IEnumerable<T> where T : class
        // allowable constraints
        //      "class" for any class
        //      specific class
        //      specific interfaces
        //      new() to require a default constructor
        //      https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    {
        private class LinkedListNode
        {
            public T Value {get; set;}
            public LinkedListNode Next { get; set; }
        }

        LinkedListNode headNode = null;

        private class LinkedListEnumerator : IEnumerator<T>
        {
            public LinkedListNode HeadNode { get; set; }
            public LinkedListNode CurrentNode { get; set; }

            public T Current => CurrentNode?.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (CurrentNode == null)
                {
                    CurrentNode = HeadNode;
                }
                else
                {
                    CurrentNode = CurrentNode.Next;
                }
                return CurrentNode != null;
            }

            public void Reset()
            {
                CurrentNode = null;
            }
        }

        LinkedListEnumerator _enumerator = new LinkedListEnumerator();

        public void Add(T newValue)
        {
            if (newValue == null) throw new ArgumentNullException();

            if (headNode != null)
            {
                LinkedListNode current = headNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new LinkedListNode() { Value = newValue };
            }
            else
            {
                headNode = new LinkedListNode() { Value = newValue };
                _enumerator.HeadNode = headNode;
            }
        }

        public void Remove( T toRemove)
        {
            //removing a node
            //node could be the head node
            //      headNode = headNode.Next;

            //node could be the last node
            //      loop until the next node is the last one, then current.Next = null

            //node could be in the middle
            //      loop until node just before, current.Next = current.Next.Next
            bool hasRemoved = false;

            if (headNode != null)
            {
                if (headNode.Value.Equals(toRemove))
                {
                    hasRemoved = true;
                    headNode = headNode.Next;
                    _enumerator.HeadNode = headNode;
                }
                else
                {
                    LinkedListNode current = headNode;

                    while (current.Next != null && !current.Next.Value.Equals(toRemove))
                    {
                        current = current.Next;
                    }

                    //what do we know is true at this point?
                    if (current.Next != null)
                    {
                        //now we know current.Next is not null, therefore 
                        //next.Value is .Equals()
                        hasRemoved = true;
                        current.Next = current.Next.Next;
                    }
                }
            }

            if (!hasRemoved) throw new ItemNotFoundException("Item not found!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            _enumerator.Reset();
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            _enumerator.Reset();
            return _enumerator;
        }
    }
}
