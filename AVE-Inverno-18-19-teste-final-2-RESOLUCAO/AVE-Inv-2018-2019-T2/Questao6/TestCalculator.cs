using System;
namespace AVEInv20182019T2.Questao6
{
    // c)
    public class TestCalculator
    {
        [Test​]
        public static void TestAdd()
        {
            UnitTest​.AssertEquals(11, 8 + 3);
        }
        [Test]
        public void TestMul()
        {
            UnitTest​.AssertEquals(444, 11 * 4);
        }
        [Test]
        public void TestSub()
        {
            UnitTest​.AssertEquals(7, 11 - 4);
        }
    }    
}
