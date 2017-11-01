using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Dapper.Extender.Helpers
{
    public class PropertyAdapterProvider<TThis>
    {
        private static readonly Dictionary<string, IPropertyAdapter<TThis>> _instances = new Dictionary<string, IPropertyAdapter<TThis>>();

        public static IPropertyAdapter<TThis> GetInstance(string forPropertyName)
        {
            if (!_instances.TryGetValue(forPropertyName, out IPropertyAdapter<TThis> instance))
            {
                var property = typeof(TThis).GetProperty(forPropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

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

                _instances.Add(forPropertyName, instance);
            }

            return instance;
        }
    }
}
