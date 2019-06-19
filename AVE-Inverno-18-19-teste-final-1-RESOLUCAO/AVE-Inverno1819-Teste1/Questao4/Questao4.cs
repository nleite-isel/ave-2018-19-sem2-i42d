using System;
namespace AVEInverno1819Teste1.Questao4
{
    delegate object Func(int p);

    //
    // EXECUTAR ILDASM PARA VER IL
    // NAO E' PRECISO COLOCAR AS LABELS NEM A INFO SOBRE ASSEMBLIES/MODULOS ENTRE []
    //

    abstract class A {
        protected Func Handlers { get; set; }
        protected int MaxNumHandlers { get; set; }
        protected A(int maxNumHandlers) {
            this.MaxNumHandlers = maxNumHandlers;
        }
    }
    class B : A {
        public B() : base(10) {
            Handlers = Bundle;
        }
        private object Bundle(int p) {
            return p;
        }
        public object InvokeAll(object parameter) {
            return Handlers((int)parameter);
        }
    }

    public class Questao4
    {
        public static void Main1() {
            
        }
    }
}
