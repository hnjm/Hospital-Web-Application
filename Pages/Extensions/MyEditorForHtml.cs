using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace EMEHospitalWebApp.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = HtmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var k = h.ViewContext.ActionDescriptor.DisplayName;
            var l = new List<object>();
            l.Add(new HtmlString("<div class=\"row\">"));
                l.Add(new HtmlString("<dd class=\"col-sm-2\">"));
                    l.Add(h.LabelFor(e, null, new { @class = "control-label" }));
                l.Add(new HtmlString("</dd>"));
                l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
                    if (k.Contains("Details") || k.Contains("Delete"))
                    {
                        l.Add(h.DisplayFor(e, null, new { @class = "form-control-plaintext" }));
                    }
                    else
                    {
                        l.Add(h.EditorFor(e, null, new { htmlAttributes = new { @class = "form-control" } }));
                        l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
                    }
                l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</div>"));
            return l;
        }
    }
}
