namespace AVEInv20182019T2.Questao6
{
    public interface IReport
    {
        void Ok(UnitTest ut);
        void Fail(UnitTest ut, AssertException e);
    }
}