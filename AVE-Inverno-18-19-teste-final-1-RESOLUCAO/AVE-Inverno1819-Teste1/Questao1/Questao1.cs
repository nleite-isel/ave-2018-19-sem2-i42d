using System;

namespace AVEInverno1819Teste1.Questao1
{
    /*
    RESPOSTAS:

Matriz:

1.

(a) F
(b) F
(c) V
(d) F

2.

(a) F
(b) F
(c) V
(d) V


3.

(a) V
(b) V
(c) F
(d) F

*/
    public class Questao1
    {
        struct V {}

        public static void Main()
        {
            //Program.Print(10);
            //int? i = null;
            //Program.Print(i);
            //V? v = null;
            //Program.Print(v);

            //Program.Print(10);
            //Program.Print(new Questao1());
            //Program.Print<object>(null);
            Program.Print<Nullable<int>>(null);

            //C c = new C();

            ////WithReturnC del3 = c.F3; // Error
            ////Derived obj = (Derived)del3(); // OK

            //WithReturnC del4 = c.F4; // OK
            //object obj1 = del4(); // OK

            //WithParamC del1 = c.F1; // OK
            //del1(new Derived()); // OK

            //WithParamC del2 = c.F2; // Error
            //del2(new Derived()); // OK

            //Console.WriteLine(obj);
        }
    }

    public delegate void WithParamC(C arg);
    public delegate C WithReturnC();

    public class C
    {
        public void F1(object obj)
        {
            Console.WriteLine("[F1] obj = " + obj);
        }
        public void F2(Derived obj)
        {
            Console.WriteLine("[F2] obj = " + obj);
        }
        public object F3()
        {
            return new Derived();
        }
        public Derived F4()
        {
            return new Derived();
        }
    }
    public class Derived : C {}



    class Program
    {
        public static void Print<T>(T t) // where T : struct
        { 

            Console.WriteLine("t: " + t.ToString()); 
        }
    }
}
