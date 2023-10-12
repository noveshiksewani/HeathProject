using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeathProject.CustomException
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }
}
