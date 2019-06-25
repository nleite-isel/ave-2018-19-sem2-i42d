using System;

//
// VER RESPOSTAS NO FICHEIRO matrizT2.txt
//


namespace AVEInverno1819Teste1.Questao1
{   
    class R { public int i; }
    struct V { public int i; }

    class IdentityAndEqualityTest
    {
        public static void Main1()
        {
            R r = new R();
            R r2 = new R();
            V v = new V();
            V v2 = new V();
            Console.WriteLine(v.Equals(v)); 
            Console.WriteLine(v.Equals(v2));
            Console.WriteLine(object.ReferenceEquals(v, v)); 
            Console.WriteLine(r.Equals(r));
            Console.WriteLine(r.Equals(r2)); 

            //Console.WriteLine(v.Equals(v)); // True, porque apesar de dois box tem o mesmo tipo exacto e os mesmos campos
            //Console.WriteLine(v.Equals(v2)); // True, idem
            //Console.WriteLine(object.ReferenceEquals(v, v)); // False, pois sao duas versoes boxed que sao comparadas
            //Console.WriteLine(r.Equals(r)); // True
            //Console.WriteLine(r.Equals(r2)); // False
        }
    }

    class A
    {
        public virtual void M()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public override void M()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public void M()
        {
            Console.WriteLine("C");
        }
    }
    class Printer
    {
        public static void Print(C c)
        {
            ((A)c).M();
            ((B)c).M();
            c.M();
        }
    }
    ////////////////////////////////////////////////
    //interface I { void M(); }
    //class A : I
    //{
    //    public virtual void M()
    //    {
    //        Console.WriteLine("A");
    //    }
    //}
    //class Printer
    //{
    //    public static void Print(I c) { 
    //        ((A)c).M();
    //        ((B)c).M();
    //        c.M();
    //    }
    //}

    class Test
    {
        public static void Main1()
        {
            Printer.Print(new C());
        }
    }
}
