using System;
using System.Reflection;

namespace AVEInverno1819Teste1
{
    public interface IPropertyFixture
    {
        void SetNewValue(object target);
        PropertyInfo GetProperty();
    }
}