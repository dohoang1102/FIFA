using System.Web.Mvc;

namespace Fifa.WebUi.ModelBinders
{
    public static class ValueProviderExtensions
    {
        public static T Get<T>(this IValueProvider provider, string key)
        {
            return (T) provider.GetValue(key).ConvertTo(typeof (T));
        }
    }
}