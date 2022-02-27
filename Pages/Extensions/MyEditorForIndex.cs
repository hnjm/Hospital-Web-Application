using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EMEHospitalWebApp.Pages.Extensions
{
    public static class MyEditorForIndex
    {
        public static IHtmlContentContainer MyEditorForLabel<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
            var s = HtmlStringsForLabel(h, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForLabel<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
            var l = new List<object>();
            l.Add(new HtmlString("<th>"));
                l.Add(h.LabelFor(e, null, new { @class = "control-label" }));
            l.Add(new HtmlString("</th>"));
            return l;
        }
        public static IHtmlContentContainer MyEditorForTable<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = HtmlStringsForTable(h, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForTable<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
            var l = new List<object>();
            l.Add(new HtmlString("<td>"));
                l.Add(h.DisplayFor(e, null, new { @class = "form-control-plaintext" }));
            l.Add(new HtmlString("</td>"));
            return l;
        }
        public static IHtmlContentContainer MyEditorForTable<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, string id) {
            var s = HtmlStringsForTable(h, e);
            s.AddRange(HtmlStringsForTable(h, id));
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForTable<TModel>(IHtmlHelper<TModel> h, string id) {
            var page = h.ViewData.Model?.GetType().Name?.Replace("Page", string.Empty);
            var l = new List<object>();
            l.Add(new HtmlString("<td>"));
                l.Add(new HtmlString("<a href=\"" + page + "/Edit?id=" + id + "&handler=Edit\">Edit</a> |&nbsp"));
                l.Add(new HtmlString("<a href=\"" + page + "/Details?id=" + id + "&handler=Details\">Details</a> |&nbsp"));
                l.Add(new HtmlString("<a href=\"" + page + "/Delete?id=" + id + "&handler=Delete\">Delete</a>"));
            l.Add(new HtmlString("</td>"));
            l.Add(new HtmlString("</tr>"));
            return l;
        }
    }
}
