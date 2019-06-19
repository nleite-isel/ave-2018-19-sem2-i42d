using System;

// 3)

namespace AVEInverno1819Teste1
{
    internal class Wrapper<R> : IFixture
    {
        private Func<R> supplier;

        public Wrapper(Func<R> supplier)
        {
            this.supplier = supplier;
        }

        public object New()
        {
            return supplier();
        }
    }
}