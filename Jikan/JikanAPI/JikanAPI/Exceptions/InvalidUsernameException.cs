using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message)
        {
        }

        public InvalidUsernameException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
