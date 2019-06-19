using System;
using System.Collections;
using System.Collections.Generic;

// 1)

namespace AVEInverno1819Teste1
{
    //internal class FixtureInt : IFixture
    // 3)
    internal class FixtureInt : IFixture<int>
    {
        public static Random random = new Random();
        public static int MAX = 10;

        public IEnumerable<int> Many(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return (int)New();
            }
        }

        public object New()
        {
            //return Fixture.random.Next(0, Fixture.MAX - 1);
            // 3)
            return random.Next(0, MAX - 1);
        }
    }
}