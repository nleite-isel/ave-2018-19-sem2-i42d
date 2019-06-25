using System;
using System.Collections.Generic;
using System.Linq;

namespace AVEInverno1819testefinal2.Questao4b
{
    // 5) [2,5]
    static class Extension
    {
        public static int GetNumColumns<T>(this IEnumerable<IEnumerable<T>> tuples)
        {
            int numColumns = 0;
            foreach (var ienum in tuples)
            {
                foreach (var item in ienum)
                {
                    ++numColumns;
                }
                break;
            }
            return numColumns;
        }

        public static IEnumerable<IEnumerable<T>> UnzipMany<T>(this IEnumerable<IEnumerable<T>> tuples)
        {
            int count = tuples.GetNumColumns();
            for (int i = 0; i < count; i++)
            {
                yield return GetSequence(tuples, i);
            }
        }

        private static IEnumerable<T> GetSequence<T>(IEnumerable<IEnumerable<T>> tuples, int col)
        {
            foreach (var ienum in tuples)
            {
                int i = 0;
                foreach (var item in ienum)
                {
                    if (i == col)
                    {
                        yield return item;
                    }
                    if (i < col)
                    {
                        ++i;
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
        ////////////////////////////////////////////////////////////////////////
        //
        // OUTRO PROCESSO
        //
        public static IEnumerable<IEnumerable<T>> UnzipMany1<T>(this IEnumerable<IEnumerable<T>> tuples)
        {
            List<IEnumerator<T>> lists = new List<IEnumerator<T>>();
            foreach (var items in tuples)
            {
                lists.Add(items.GetEnumerator());
            }
            for (int i = 0; i < lists.Count(); i++) // Funciona tambem se matriz nao for quadrada 
            {
                yield return GetSequence1(lists);
            }
        }

        private static IEnumerable<T> GetSequence1<T>(List<IEnumerator<T>> src)
        {
            foreach (var ienumerator in src)
            {
                if (ienumerator.MoveNext())
                {
                    yield return ienumerator.Current;
                }
            }
        }
    }

    public class Questao4
    {
        public static void Main1()
        {
            List<IEnumerable<object>> tuples = new List<IEnumerable<object>>();
            tuples.Add(new object[] { "a", 1, "A" });
            tuples.Add(new object[] { "b", 2, "B" });
            tuples.Add(new object[] { "c", 3, "C" });
            // Added
            tuples.Add(new object[] { "d", 4, "D" });

            IEnumerable<IEnumerable<object>> original = tuples.UnzipMany();
            foreach (IEnumerable<object> s in original)
            {
                Console.WriteLine(String.Join(",", s)); 
            }

            Console.WriteLine();
            IEnumerable<IEnumerable<object>> original1 = tuples.UnzipMany1();
            foreach (IEnumerable<object> s in original1)
            {
                Console.WriteLine(String.Join(",", s));
            }
//a,b,c
//1,2,3
//A,B,C

        }
    }
}
