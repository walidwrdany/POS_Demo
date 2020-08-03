using POS_Demo.Helper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace POS_Demo.Helper
{
    public static class HMTLHelperExtensions
    {
        private const string endFieldPattern = "^(.*?)>";
        private static Random random = new Random();
        private static string[] _colors = { "success", "warning", "danger", "warning", "primary", "danger", "dark" };

        public static string IsSelected(this HtmlHelper html, string action = null, string controller = null, CssClass cssClass = CssClass.Select)
        {
            string _cssClass = cssClass.GetDisplayName();
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ? _cssClass : string.Empty;
        }

        public static string IsSelected(this HtmlHelper html, string action = null, List<string> controllers = null, CssClass cssClass = CssClass.Select)
        {
            string _cssClass = cssClass.GetDisplayName();
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            var re = controllers.Select(Controller => string.IsNullOrEmpty(Controller) ? currentController : Controller).Any(Controller => Controller.ToLower() == currentController.ToLower() && action.ToLower() == currentAction.ToLower());
            return re ? _cssClass : string.Empty;
        }

        public static string GetAreaName(this HtmlHelper html)
        {
            return (string)HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
        }

        public static string GetControllerName(this HtmlHelper html)
        {
            return (string)html.ViewContext.RouteData.Values["controller"];
        }

        public static string GetActionName(this HtmlHelper html)
        {
            return (string)html.ViewContext.RouteData.Values["action"];
        }

        public static MvcHtmlString Attribute(this HtmlHelper helper, string name, string value, bool condition)
        {
            return ((!string.IsNullOrEmpty(name)) && (!string.IsNullOrEmpty(value)) && condition)
                ? new MvcHtmlString(string.Format("{0}=\"{1}\"", name, HttpUtility.HtmlAttributeEncode(value)))
                : MvcHtmlString.Empty;
        }

        public static MvcHtmlString IsDisabled(this MvcHtmlString htmlString, bool condition)
        {
            string rawString = htmlString.ToString();
            if (condition)
                rawString = Regex.Replace(rawString, endFieldPattern, "$1 disabled=\"disabled\">");
            return new MvcHtmlString(rawString);
        }

        public static MvcHtmlString IsReadonly(this MvcHtmlString htmlString, bool condition)
        {
            string rawString = htmlString.ToString();
            if (condition)
                rawString = Regex.Replace(rawString, endFieldPattern, "$1 readonly=\"readonly\">");
            return new MvcHtmlString(rawString);
        }

        public static MvcHtmlString IsNew(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create("<span class=\"kt-menu__link-badge\"><span class=\"kt-badge kt-badge--danger kt-badge--inline\">2</span></span>");
        }

        public static string ToSentence(this string Input)
        {
            return !string.IsNullOrWhiteSpace(Input)
                ? new string(Input.SelectMany((c, i) => i > 0 && char.IsUpper(c) ? new[] { ' ', c } : new[] { c }).ToArray())
                : string.Empty;
        }

        public static string RandomStateColors(this HtmlHelper html)
        {
            return _colors[random.Next(0, _colors.Length)];
        }



    }
}