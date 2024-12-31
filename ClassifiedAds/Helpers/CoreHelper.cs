using ClassifiedAds.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassifiedAds.Helpers
{
    public class CoreHelper
    {
        public static string GetUniqueToken()
        {
            return Path.GetRandomFileName().Replace(".", ""); 
        }

        public static SelectList GetEnumDropDownList<T>()
        {
            var data =  new SelectList(Enum.GetValues(typeof(T)));
            return data;
        }
    }
}
