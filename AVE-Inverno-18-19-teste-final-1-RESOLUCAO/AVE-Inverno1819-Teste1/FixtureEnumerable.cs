using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace AVEInverno1819Teste1
{
    //
    // POSSIBLE IMPLEMENTATION DETAILS (NOT ASKED)
    //

    internal class FixtureEnumerable : IFixture
    {
        private Type propertyType;
        public static Random random = new Random();


        public FixtureEnumerable(Type propertyType)
        {
            this.propertyType = propertyType;
        }

        public object New()
        {
            return GenerateEnumerable(propertyType);
        }

        private IEnumerable GenerateEnumerable(Type type)
        {
            Type typeArg = type.GetGenericArguments()[0];
            // Call GetOrCreateFixture static method. This method should be in a cache class.
            // TODO: Improve design
            // 3)
            Type[] typeArgs = { typeArg };
            MethodInfo methodGet = typeof(Fixture<object>).GetMethod("GetOrCreateFixtureGeneric");
            MethodInfo generic = methodGet.MakeGenericMethod(typeArgs);
            var cachedFix = generic.Invoke(null, new Type[] { typeArg });
            // Invoke 'Many' method
            MethodInfo method = cachedFix.GetType().GetMethod("Many");
            return (IEnumerable)method.Invoke(cachedFix, new object[] { random.Next(10) });
        }
    }
}
















