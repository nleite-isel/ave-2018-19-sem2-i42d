using System;
namespace AVEInv20182019T2.Questao6
{
    public class ConsoleReport : IReport
    {
        public void Fail(UnitTest ut, AssertException e)
        {
            Console.WriteLine("FAILED " + ut.Name + ": " + e.Message);
        }

        public void Ok(UnitTest ut)
        {
            Console.WriteLine("OK " + ut.Name);
        }
    }
}
