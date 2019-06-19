using System.Collections;
using System.Collections.Generic;

namespace AVEInverno1819Teste1
{
    public interface IFixture
    {
        object New();
    }

    public interface IFixture<T> : IFixture
    {
        //new T New(); // Not asked
        IEnumerable<T> Many(int size);
    }
}