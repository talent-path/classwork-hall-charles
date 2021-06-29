using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JikanAPI.Exceptions
{
    public class WatchNotFoundException : Exception
    {
        public WatchNotFoundException(string message) : base(message)
        {
        }

        public WatchNotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
