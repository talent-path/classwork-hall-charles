using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message)
        {
        }

        public InvalidNameException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
