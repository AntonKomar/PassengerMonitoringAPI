using System;
using System.Linq;
using System.Reflection;

namespace PassengersMonitoring.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool ContainsAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return propertyInfo.GetCustomAttributes<TAttribute>().FirstOrDefault() != null;
        }
    }
}
