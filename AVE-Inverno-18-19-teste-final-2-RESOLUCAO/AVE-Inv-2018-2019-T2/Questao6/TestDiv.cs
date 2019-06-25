using System;
namespace AVEInv20182019T2.Questao6
{
    [Expected(typeof(DivideByZeroException))]
    public class TestDiv : UnitTest
    {
        public override string Name => "TestDiv";

        public override void Test()
        {
            int zero = 0;
            int res = 7 / zero;
        }
    }

    [Expected(typeof(FormatException))]
    public class TestDivFail : UnitTest
    {
        public override string Name => "TestDivFail";

        public override void Test()
        {
            int res = 7 / 3;
        }
    }

}
