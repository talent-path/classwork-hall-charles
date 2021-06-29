using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message)
        {
        }

        public InvalidQuantityException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
