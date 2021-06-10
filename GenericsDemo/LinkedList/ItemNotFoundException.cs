using System;
namespace LinkedList
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg) : base(msg)
        {

        }

        public ItemNotFoundException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}
