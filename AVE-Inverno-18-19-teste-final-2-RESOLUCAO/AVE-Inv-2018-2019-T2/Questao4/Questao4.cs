using System;
namespace AVEInverno1819Teste1.Questao4
{

    // 
    // EXECUTAR ILDASM
    //

    delegate int Func(object p);

    interface IFixture {
        object New();
    }

    class A : IFixture {
        public Func Handlers { get; set; }
        private int max;

        public A(int max) {
            this.max = max;
            Handlers = M;
        }
        private static int M(object obj) {
            Console.WriteLine("M: {0}", obj);
            return 10;
        }
        public object New()
        {
            return Handlers(max);
        }
    }

    public class Questao4
    {
        public static void Main1() {
            Console.WriteLine(new A(5).New());   
        }
    }
}
