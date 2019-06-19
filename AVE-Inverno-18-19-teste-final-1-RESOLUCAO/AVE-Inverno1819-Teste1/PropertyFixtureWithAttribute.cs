using System.Reflection;

namespace AVEInverno1819Teste1
{
    internal class PropertyFixtureWithAttribute : IPropertyFixture
    {
        private PropertyInfo property;
        private IFixture fixture;
        ValidationAttribute attribute;

        public PropertyFixtureWithAttribute(PropertyInfo property, IFixture fixture)
        {
            this.property = property;
            this.fixture = fixture;
            attribute = (ValidationAttribute)property.GetCustomAttribute(typeof(ValidationAttribute), false);
        }

        public PropertyInfo GetProperty()
        {
            return property;
        }

        public void SetNewValue(object target)
        {
            object value = fixture.New();
            if (attribute.Validate(value))
            {
                property.SetValue(target, value);
            }
        }
    }
}