using System;
using System.Runtime.Serialization;

namespace AVEInv20182019T2.Questao6
{
    public class AssertException : Exception
    {
        public AssertException(string message) : base(message)
        {
        }
    }
}