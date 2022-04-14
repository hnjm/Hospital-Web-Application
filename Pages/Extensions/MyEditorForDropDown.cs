using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EMEHospitalWebApp.Pages.Extensions
{
    public static class MyEditorForDropDown {
        public static IHtmlContentContainer MyDropDownFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> list) {
            var s = HtmlStrings(h, e, list);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> list) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dd class=\"col-sm-2\">"),
                h.LabelFor(e, null, new { @class = "control-label" }),
                new HtmlString("</dd>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.DropDownListFor(e, list, null, new { @class = "form-control" }),
                h.ValidationMessageFor(e, null, new { @class = "text-danger" }),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return l;
        }
    }
}
