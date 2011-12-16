using System.Web.Mvc;

namespace Fifa.WebUi.Helpers
{
    public static class UrlHelpers
    {
        public static string Image(this UrlHelper helper, string name)
        {
            return helper.Content("~/Images/" + name);
        }
    }
}