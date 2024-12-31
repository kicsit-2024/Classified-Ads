using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace ClassifiedAds.Helpers
{
    public static class ExtensionMethods
    {
        public static int WordCounter(this string value)
        {
            return value.Split(' ').Count();
        }

        public static SelectList GetEnumDropDownList<T>(this IHtmlHelper _)
        {
            var data = new SelectList(Enum.GetValues(typeof(T)));
            return data;
        }

        public static void CopyProperties(this object source, object target)
        {
            var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in sourceProperties)
            {
                var targetProperty = target.GetType().GetProperty(property.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = property.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }
        }
    }
}
