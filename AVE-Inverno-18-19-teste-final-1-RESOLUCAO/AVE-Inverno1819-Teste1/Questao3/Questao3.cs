using System;
using System.Collections.Generic;

namespace AVEInverno1819Teste1.Questao3
{


    static class Extension {
        public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(
                   this IEnumerable<TValue> values,
                   Predicate<TValue> pred)
        {
            using (var enumerator = values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return GetChunk(enumerator, pred);
                }
            }
        }
        private static IEnumerable<T> GetChunk<T>(
                         IEnumerator<T> enumerator,
                         Predicate<T> pred)
        {
            do
            {
                yield return enumerator.Current;
            } while (!pred(enumerator.Current) && enumerator.MoveNext());
        }

    }

    public class Questao3
    {
        public static void Main1() {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<IEnumerable<int>> chunked = numbers.Chunk(v => v % 2 == 0);
            foreach (IEnumerable<int> s in chunked)
            {
                Console.WriteLine(String.Join(",", s));
            }
        }
    }
}
