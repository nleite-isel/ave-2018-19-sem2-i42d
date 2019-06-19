using System;
using System.Reflection;


// 1)

namespace AVEInverno1819Teste1
{
    internal class PropertyFixture : IPropertyFixture
    {
        private PropertyInfo property;
        private IFixture fix;

        public PropertyFixture(PropertyInfo property, IFixture fix)
        {
            this.property = property;
            this.fix = fix;
        }

        public PropertyInfo GetProperty()
        {
            return property;
        }

        public void SetNewValue(object target)
        {
            property.SetValue(target, fix.New());
        }
    }
}