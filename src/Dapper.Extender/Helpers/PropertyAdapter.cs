using System;

namespace Dapper.Extender.Helpers
{
    public class PropertyAdapter<TThis, TResult> : IPropertyAdapter<TThis>
    {
        private readonly Func<TThis, TResult> getter;

        public PropertyAdapter(Func<TThis, TResult> getterInvocation)
        {
            getter = getterInvocation;
        }

        public object InvokeGet(TThis @this)
        {
            return getter.Invoke(@this);
        }
    }
}
