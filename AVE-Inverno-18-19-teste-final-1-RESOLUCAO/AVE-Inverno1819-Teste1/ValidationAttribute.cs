using System;
using System.Reflection;

// 4)

namespace AVEInverno1819Teste1
{
    public class BindFlags
    {
        public static BindingFlags ALL = BindingFlags.Public
                                         | BindingFlags.Static
                                         | BindingFlags.Instance
                                         | BindingFlags.NonPublic
                                         | BindingFlags.FlattenHierarchy;
    }

    // Falta usage
    public class ValidationAttribute : Attribute
    {
        private MethodInfo method;

        public ValidationAttribute(string methodName)
        {
            this.method = typeof(ValidationMethods).GetMethod(methodName, BindFlags.ALL);
        }

        public bool Validate(object parameter) {
            return (bool)method.Invoke(null, new object[] { parameter } );
        }
    }

    public class ValidationMethods
    {
        static bool CheckNumberLessThan50000(object obj)
        {
            Console.WriteLine("[CheckNumberLessThan50000] obj = {0}", obj.ToString());
                   
            // Assume obj refers to a valid integer
            int number = (int)obj;
            return number < 50000;
        }
    }
}