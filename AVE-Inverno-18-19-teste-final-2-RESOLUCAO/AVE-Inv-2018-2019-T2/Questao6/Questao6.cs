using System;
namespace AVEInv20182019T2.Questao6
{
    public class Questao6
    {
        public static void Main()
        {
            TestSuite tester = new TestSuite(new ConsoleReport());
            //tester.Add(new TestAdd());
            //tester.Add(new TestLength());
            ////tester.Add(new TestDiv());
            ////tester.Add(new TestDivFail());

            //tester.Run();

            //TestSuite​ tester = new TestSuite(new ConsoleReport());
            //tester.Add("TestAdd", () => UnitTest​.AssertEquals(11, 8 + 3));
            //tester.Add("TestMul", () => UnitTest​.AssertEquals(444, 11 * 4));
            //tester.Add("TestSub", () => UnitTest​.AssertEquals(7, 11 - 4));

            //// c)
            tester.Add(typeof(TestCalculator));
            tester.Run();
        }
    }
}

//Output:

//OK TestAdd
//FAILED TestLength: Expected 7 but actual is 4













