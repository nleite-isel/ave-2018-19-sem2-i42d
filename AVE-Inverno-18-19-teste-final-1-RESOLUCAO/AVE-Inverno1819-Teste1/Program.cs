﻿using System;
using Fixtr;

namespace AVEInverno1819Teste1
{
    class MainClass
    {
        public static void Main1(string[] args)
        {
            //Fixture fixture = new Fixture(typeof(Student));
            Fixture<Student> fixture = new Fixture<Student>(typeof(Student));

            //fixture.SetSupplier<int>("Nr", () => 10);

            var autoGeneratedClass = fixture.New();

            Console.WriteLine(autoGeneratedClass);
        }
    }
}
