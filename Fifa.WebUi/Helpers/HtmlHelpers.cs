using System.Web.Mvc;

namespace Fifa.WebUi.Helpers
{
    public static class HtmlHelpers
    {
        public static bool IsControllerAction(
           this ViewContext context, string controller, string action)
        {
            var valueProvider = context.Controller.ValueProvider;

            var currentAction = valueProvider.GetValue(
                "action").RawValue as string;
            var currentController = valueProvider.GetValue(
                "controller").RawValue as string;

            return currentController == controller && currentAction == action;
        }

        public static MvcHtmlString NavigationLink<T>(
            this HtmlHelper<T> helper, string meta, string text,
            string action, string controller = null)
        {
            var valueProvider = helper.ViewContext.Controller.ValueProvider;
            var currentController = valueProvider.GetValue("controller").RawValue as string;

            controller = controller ?? currentController;

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var linkUrl = urlHelper.Action(action, controller);
            var linkText = string.Format("<span class=\"meta\">{0}</span><br />{1}</a>", meta, text);
            var linkClass = helper.ViewContext.IsControllerAction(controller, action) ? "class=\"current\"" : string.Empty;

            var builder = new TagBuilder("li")
                {
                    InnerHtml = string.Format("<a href=\"{0}\"{2}>{1}</a>", linkUrl, linkText, linkClass)
                };

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}