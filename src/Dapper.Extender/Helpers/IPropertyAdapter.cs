namespace Dapper.Extender.Helpers
{
    public interface IPropertyAdapter<TThis>
    {
        object InvokeGet(TThis @this);
    }
}
