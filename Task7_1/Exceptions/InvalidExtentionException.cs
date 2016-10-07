using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_1.Exceptions
{
    public class InvalidExtensionException : Exception
    {
        public InvalidExtensionException(string message) : base(message)
        {

        }
    }
}
