using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMCounter
{
    public class NegativeNumberException : System.Exception
    {
        public NegativeNumberException()
        {
        }

        public NegativeNumberException(string message)
            : base(message)
        {
        }

        public NegativeNumberException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
