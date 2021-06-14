using System;
namespace VendingMachine.exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }

        public InsufficientFundsException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
