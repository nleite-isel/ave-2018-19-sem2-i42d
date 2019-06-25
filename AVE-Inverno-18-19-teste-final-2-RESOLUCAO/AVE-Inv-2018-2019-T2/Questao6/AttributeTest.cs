namespace AVEInv20182019T2.Questao6
{
    // a)
    internal class AttributeTest : UnitTest
    {
        private UnitTest ut;
        private ExpectedAttribute attr;

        public AttributeTest(UnitTest ut) 
        {
            this.ut = ut;
            attr = (ExpectedAttribute) ut.GetType()
                                         .GetCustomAttributes(typeof(ExpectedAttribute), false)[0];
        }

        public override string Name => ut.Name;

        public override void Test()
        {
            try
            {
                ut.Test();
            }
            catch (System.Exception ex)
            {
                AssertEquals(ex.GetType(), attr.ExceptionType);
                return;
            }
            throw new AssertException("Expected " + attr.ExceptionType + " exception not thrown!");
        }
    }
}