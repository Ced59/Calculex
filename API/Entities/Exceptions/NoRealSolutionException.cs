using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class NoRealSolutionException : Exception
    {
        public NoRealSolutionException() { }

        public NoRealSolutionException(string message)
            : base(message) { }

        public NoRealSolutionException(string message, Exception inner)
            : base(message, inner) { }
    }
}
