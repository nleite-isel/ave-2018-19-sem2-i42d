using System;

namespace AVEInv20182019T2.Questao6
{
    // b)
    internal class DelegateTest : UnitTest
    {
        private string name;
        private Action handler;

        public DelegateTest(string name, Action handler)
        {
            this.name = name;
            this.handler = handler;
        }

        public override string Name => name;

        public override void Test()
        {
            handler();
        }
    }
}