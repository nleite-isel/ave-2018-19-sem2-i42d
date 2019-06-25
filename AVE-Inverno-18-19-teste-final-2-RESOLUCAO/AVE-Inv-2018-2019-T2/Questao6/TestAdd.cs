using System;
namespace AVEInv20182019T2.Questao6
{
    public class TestAdd : UnitTest
    {
        public override string Name
        {
            get { return "TestAdd"; }
        }
        public override void Test()
        {
            AssertEquals(7, 3 + 4);
        }
    }
}
