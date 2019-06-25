using System;
namespace AVEInv20182019T2.Questao6
{
    public class TestLength : UnitTest
    {
        public override string Name => "TestLength";

        public override void Test()
        {
            AssertEquals(7, "ISEL".Length);
        }
    }
}
