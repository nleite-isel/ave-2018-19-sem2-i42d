using System;

namespace AVEInv20182019T2.Questao6
{
    public abstract class UnitTest
    {
        public abstract string Name { get; }
        public abstract void Test();
        public static void AssertEquals<T>(T expected, T actual)
        {
            if (!expected.Equals(actual))
            {
                throw new AssertException("Expected "
                                          + expected + " but actual is "
                                          + actual);
            }
        }
    }
}