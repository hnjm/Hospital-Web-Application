using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EMEHospitalWebApp.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContentContainer MyEditorForCRUD<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = HtmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContentContainer MyEditorForCRUD<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, TResult value) {
            var s = HtmlStrings(h, e, value);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var k = h.ViewContext.ActionDescriptor.DisplayName;
            var l = new List<object>
            {
                new HtmlString("<div class=\"row\">"),
                new HtmlString("<dd class=\"col-sm-2\">"),
                h.LabelFor(e, null, new { @class = "control-label" }),
                new HtmlString("</dd>"),
                new HtmlString("<dd class=\"col-sm-10\">")
            };
            if (k.Contains("Details") || k.Contains("Delete"))
                l.Add(h.DisplayFor(e));
            else
            {
                l.Add(h.EditorFor(e, null, new { htmlAttributes = new { @class = "form-control" } }));
                l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
            }
            l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</div>"));
            return l;
        }
        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, TResult value) {
            var k = h.ViewContext.ActionDescriptor.DisplayName;
            var l = new List<object>
            {
                new HtmlString("<div class=\"row\">"),
                new HtmlString("<dd class=\"col-sm-2\">"),
                h.LabelFor(e, null, new { @class = "control-label" }),
                new HtmlString("</dd>"),
                new HtmlString("<dd class=\"col-sm-10\">")
            };
            if (k.Contains("Details") || k.Contains("Delete")) {
                l.Add(h.Raw(value));
            } else {
                l.Add(h.EditorFor(e, null, new { htmlAttributes = new { @class = "form-control" } }));
                l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
            }
            l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</div>"));
            return l;
        }
    }
}
