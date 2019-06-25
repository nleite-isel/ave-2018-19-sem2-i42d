using System;

namespace AVEInv20182019T2.Questao6
{
    // a)
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class ExpectedAttribute : Attribute
    {
        public ExpectedAttribute(Type type) {
            ExceptionType = type;
        }

        public Type ExceptionType { get; private set; }
    }
}
