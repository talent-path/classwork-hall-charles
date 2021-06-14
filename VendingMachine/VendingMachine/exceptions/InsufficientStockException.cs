using System;
namespace VendingMachine.exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message)
        {
        }

        public InsufficientStockException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
