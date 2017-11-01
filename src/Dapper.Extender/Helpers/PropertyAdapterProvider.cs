using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dapper.Extender.Helpers
{
    public class PropertyAdapterProvider<TThis>
    {
        private static readonly Dictionary<string, IPropertyAdapter<TThis>> instances = new Dictionary<string, IPropertyAdapter<TThis>>();

        public static IPropertyAdapter<TThis> GetInstance(string propertyName)
        {
            if (!instances.TryGetValue(propertyName, out IPropertyAdapter<TThis> instance))
            {
                var property = typeof(TThis).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                MethodInfo getMethod;
                Delegate getterInvocation = null;
                if (property != null && (getMethod = property.GetGetMethod(true)) != null)
                {
                    var openGetterType = typeof(Func<,>);
                    var concreteGetterType = openGetterType.MakeGenericType(typeof(TThis), property.PropertyType);

                    getterInvocation = Delegate.CreateDelegate(concreteGetterType, null, getMethod);
                }
                else
                {
                    //throw exception or create a default getterInvocation returning null
                }

                var openAdapterType = typeof(PropertyAdapter<,>);
                var concreteAdapterType = openAdapterType.MakeGenericType(typeof(TThis), property.PropertyType);
                instance = Activator.CreateInstance(concreteAdapterType, getterInvocation) as IPropertyAdapter<TThis>;

                instances.Add(propertyName, instance);
            }

            return instance;
        }
    }
}
