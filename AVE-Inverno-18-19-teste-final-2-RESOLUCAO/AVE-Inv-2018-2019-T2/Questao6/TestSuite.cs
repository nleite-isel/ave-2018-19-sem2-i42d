using System;
using System.Collections.Generic;
using System.Reflection;

namespace AVEInv20182019T2.Questao6
{
    public class TestSuite​
    {
        List​<UnitTest​> tests;
        IReport​ report;
        public TestSuite(IReport​ consoleReport) 
        {
            this.tests = new List<UnitTest>();
            this.report = consoleReport;
        }
        public void Add(UnitTest​ ut)
        {
            // a)
            if (Attribute.IsDefined(ut.GetType(), typeof(ExpectedAttribute)))
            {
                tests.Add(new AttributeTest(ut));
            }
            else
            {
                tests.Add(ut);
            }
        }
        public void Run()
        {
            foreach (UnitTest ut in tests)
            {
                try
                {
                    ut.Test();
                    report.Ok(ut);
                }
                catch (AssertException e)
                {
                    report.Fail(ut, e);
                }
            }
        }

        // b)
        public void Add(string name, Action handler) {
            tests.Add(new DelegateTest(name, handler));
        }
        // d)
        public void Add(Type type) {
            var methInfos = type.GetMethods(BindingFlags.Public |
                                            BindingFlags.Instance |
                                            BindingFlags.Static);
            // Get methodInfos
            foreach (var meth in methInfos)
            {
                // Check signature and attribute
                if (CheckSignature(meth) && Attribute.IsDefined(meth, typeof(TestAttribute)))
                {
                    if (meth.IsStatic)
                    {
                        tests.Add(new DelegateTest(meth.Name,
                                               () => meth.Invoke(null, null)));
                    }
                    else
                    {
                        tests.Add(
                             new DelegateTest(meth.Name, () =>
                             {
                                 try
                                 {
                                    // TODO OPTIMIZATION: Create target only once
                                    meth.Invoke(Activator.CreateInstance(type), null);

                                 }
                                 catch (Exception ex)
                                 {
                                // When invoking method via reflection and an exception is thrown (e.g. AssertException), 
                                // a TargetInvocationException is thrown. We have to catch this exception and rethrow the 
                                // inner exception (AssertException)
                                     if (ex.InnerException != null)
                                     {
                                        string err = ex.InnerException.Message;
                                        // Rethrow AssertException
                                        throw ex.InnerException;
                                     }
                                 }
                             }
                         ));
                    }
                }
            }
        }

        private bool CheckSignature(MethodInfo meth)
        {
            // Check if it has empty parameter list
            return meth.GetParameters().Length == 0;
        }
    }
}










