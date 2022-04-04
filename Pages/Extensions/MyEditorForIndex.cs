using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Pages.Extensions
{
    public static class MyEditorForIndex
    {
        public static IHtmlContentContainer ShowTable<TModel, TView>(this IHtmlHelper<TModel> h, IList<TView>? items) 
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var s = HtmlStringsForIndex(h, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForIndex<TView, TModel>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var l = new List<object>();
            var m = h.ViewData.Model;
            l.Add(new HtmlString("<thead>"));
                foreach (var name in m.IndexColumns) {
                    l.Add(h.MyEditorForLabel(name));
                }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
                foreach (var item in m.Items ?? new List<TView>()) {
                    foreach (var name in m.IndexColumns) {
                        l.Add(h.MyEditorForTable(m.GetValue(name, item)));
                    }
                    l.Add(h.MyEditorForButtons(item.Id));
                }
            return l;
        }
        public static IHtmlContentContainer MyEditorForLabel<TModel>(
            this IHtmlHelper<TModel> h, string name) {
            var s = HtmlStringsForLabel(name, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForLabel(string name, IPageModel? m) {
            var pageName = m?.GetType()?.Name?.Replace("Page", "");
            var l = new List<object>();
            l.Add(new HtmlString("<th>"));
                l.Add(new HtmlString($"<a href=\"/{pageName}?"));
                l.Add(new HtmlString($"handler=Index&amp;"));
                l.Add(new HtmlString($"order={m?.SortOrder(name)}&amp;"));
                l.Add(new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"));
                l.Add(new HtmlString($"filter={m?.CurrentFilter}\">"));
                l.Add(new HtmlString($"{name}</a>"));
            l.Add(new HtmlString("</th>"));
            return l;
        }
        public static IHtmlContentContainer MyEditorForTable<TModel>(
            this IHtmlHelper<TModel> h, object e) {
            var s = HtmlStringsForTable(h, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForTable<TModel>(IHtmlHelper<TModel> h, object e) {
            var l = new List<object>();
            if (e.ToString()!.Contains("modelItem")) return l;
            l.Add(new HtmlString("<td>"));
                l.Add(h.Raw(e));
            l.Add(new HtmlString("</td>"));
            return l;
        }
        public static IHtmlContentContainer MyEditorForButtons<TModel>(
            this IHtmlHelper<TModel> h, string? id) {
            var s = HtmlStringsForButtons(h, id);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForButtons<TModel>(IHtmlHelper<TModel> h, string? id) {
            var page = h.ViewData.Model?.GetType().Name?.Replace("Page", string.Empty);
            var l = new List<object>();
            l.Add(new HtmlString("<td>"));
            l.Add(h.MyEditorForButtons("Edit", id));
            l.Add(new HtmlString(" |&nbsp"));
            l.Add(h.MyEditorForButtons("Details", id));
            l.Add(new HtmlString(" |&nbsp"));
            l.Add(h.MyEditorForButtons("Delete", id));
            l.Add(new HtmlString("</td>"));
            l.Add(new HtmlString("</tr>"));
            return l;
        }
        public static IHtmlContentContainer MyEditorForButtons<TModel>(
            this IHtmlHelper<TModel> h, string name, string id) {
            var s = HtmlStringsForLabel(name, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForLabel(string name, string id, IPageModel? m) {
            var pageName = m?.GetType()?.Name?.Replace("Page", "");
            var l = new List<object>();
            l.Add(new HtmlString($"<a href=\"/{pageName}/{name}?"));
            l.Add(new HtmlString($"handler={name}&amp;"));
            l.Add(new HtmlString($"id={id}&amp;"));
            l.Add(new HtmlString($"order={m?.CurrentOrder}&amp;"));
            l.Add(new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"));
            l.Add(new HtmlString($"filter={m?.CurrentFilter}\">"));
            l.Add(new HtmlString($"{name}</a>"));
            return l;
        }
        
    }
}
