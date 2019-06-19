using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace AVEInverno1819Teste1
{
    //public class Fixture : IFixture
    public class Fixture<T> : IFixture<T>
    {
        // Dado
        public static int MAX = 10;
        public static Random random = new Random();
        private Type targetType;
        private static Dictionary<Type, IFixture> fixtures = new Dictionary<Type, IFixture>();
        private List<IPropertyFixture> propertyFixtures = new List<IPropertyFixture>();

        // Dado
        /*private*/ public static IFixture GetOrCreateFixture(Type type)
        {
            IFixture fix = null;
            if (fixtures.ContainsKey(type))
            {
                fix = fixtures[type];
            }
            else
            {
                //fix = new Fixture(type);
                // 3)
                Type[] typeArgs = { type };
                var makeme = typeof(Fixture<>).MakeGenericType(typeArgs);
                fix = (IFixture)Activator.CreateInstance(makeme, typeArgs);

                fixtures.Add(type, fix);
            }
            return fix;
        }

        //
        // POSSIBLE IMPLEMENTATION DETAILS (NOT ASKED)
        //
        public static IFixture<R> GetOrCreateFixtureGeneric<R>(Type type)
        {
            IFixture fix = null;
            if (fixtures.ContainsKey(type))
            {
                fix = fixtures[type];
            }
            else
            {
                // 3)
                fix = new Fixture<R>(type);

                fixtures.Add(type, fix);
            }
            return (IFixture<R>)fix;
        }

        // Dado
        static Fixture()
        {
            // Add fixtures for primitive types
            fixtures.Add(typeof(int), new FixtureInt());
            // other fixtures...
        }
        ////////////////////////////////////////////////////////////
        // 1)
        public Fixture(Type type) // ONLY FOR REFERENCE TYPES
        {
            this.targetType = type;
            CreatePropertyFixtures();
        }
        // 1)
        private void CreatePropertyFixtures()
        {
            foreach (var property in targetType.GetProperties())
            {
                // 5)
                if (Attribute.IsDefined(property, typeof(ValidationAttribute)))
                {
                    propertyFixtures.Add(new PropertyFixtureWithAttribute(property, GetOrCreateFixture(property.PropertyType)));
                }
                //////////////////////////////////////////
                // 3) IEnumerable<T> 
                //
                // POSSIBLE IMPLEMENTATION DETAILS (NOT ASKED)
                //
                else if (property.PropertyType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                //else if (property.PropertyType == typeof(IEnumerable<int>))
                {
                    propertyFixtures.Add(new PropertyFixture(property, new FixtureEnumerable(property.PropertyType)));
                }
                //////////////////////////////////////////
                else
                    // 1)
                    propertyFixtures.Add(new PropertyFixture(property, GetOrCreateFixture(property.PropertyType)));
            }
        }
        ////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////

        //public T New()
        //{
        //    object target = InitialiseObject();
        //    // Initialise properties
        //    InitialiseProperties(target);
        //    return (T)target;
        //}

        //object IFixture.New()
        //{
        //    return New();
        //}

        // 2)
        public object New()
        {
            object target = InitialiseObject();
            // Initialise properties
            InitialiseProperties(target);
            return (T)target;
        }

        // 2)
        private object InitialiseObject()
        {
            // Ctors
            var ctors = targetType.GetConstructors();
            var constructorInfo = ctors[random.Next(0, ctors.Length - 1)];
            // Get parameter list
            var parameterList = constructorInfo.GetParameters();
            object[] parameterValues = new object[parameterList.Length];
            int i = 0;
            foreach (var parameter in parameterList)
            {
                parameterValues[i] = BuildParameter(parameter);
                ++i;
            }
            object target = constructorInfo.Invoke(parameterValues);
            return target;
        }

        // 2)
        private object BuildParameter(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;
            IFixture fix = GetOrCreateFixture(parameterType);
            return fix.New();
        }

        // 2)
        private void InitialiseProperties(object target)
        {
            foreach (var propertyFixture in propertyFixtures)
            {
                propertyFixture.SetNewValue(target);
            }
        }
        ////////////////////////////////////////////////////////////

        // 4)
        public void SetSupplier<R>(String memberName, Func<R> supplier)
        {
            // Find and remove PropertySetter for this property
            var propertyFixture = propertyFixtures.Find(p => p.GetProperty().Name.Equals(memberName));
            propertyFixtures.Remove(propertyFixture);
            // Add supplier PropertySetter
            propertyFixtures.Add(new PropertyFixture(targetType.GetProperty(memberName), new Wrapper<R>(supplier)));

        }

        public IEnumerable<T> Many(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return (T)New();
            }
        }
        ////////////////////////////////////////////////////////////
    }
}

