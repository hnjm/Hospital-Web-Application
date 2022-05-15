using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Pages.Extensions {
    public static class MyEditorForIndex {
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
                    l.Add(h.MyEditorForLabel(m.DisplayName(name)));
                }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
                foreach (var item in items ?? new List<TView>()) {
                    foreach (var name in m.IndexColumns) {
                        l.Add(h.MyEditorForTable(m.GetValue(name, item)));
                    }
                    l.Add(h.MyEditorForButtons(item.Id));
                }
            return l;
        }
        public static IHtmlContentContainer MyEditorForLabel<TModel>(
            this IHtmlHelper<TModel> h, string? name) {
            var s = HtmlStringsForLabel(name, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForLabel(string? name, IPageModel? m) {
            name ??= "Unspecified";
            var pageName = m?.GetType()?.Name?.Replace("Page", "");
            var l = new List<object> {
                new HtmlString("<th>"),
                new HtmlString($"<a style=\"text-decoration:none;\" href=\"/{pageName}?"),
                new HtmlString($"handler=Index&amp;"),
                new HtmlString($"order={m?.SortOrder(name)}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{name}</a>"),
                new HtmlString("</th>")
            };
            return l;
        }
        public static IHtmlContentContainer MyEditorForTable<TModel>(
            this IHtmlHelper<TModel> h, object? e) {
            var s = HtmlStringsForTable(h, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForTable<TModel>(IHtmlHelper<TModel> h, object? e) {
            var l = new List<object>();
            if (e != null && e.ToString()!.Contains("modelItem")) return l;
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
            var l = new List<object> {
                new HtmlString("<td>"),
                h.MyEditorForButtons("Edit", id),
                new HtmlString(" |&nbsp"),
                h.MyEditorForButtons("Details", id),
                new HtmlString(" |&nbsp"),
                h.MyEditorForButtons("Delete", id),
                new HtmlString("</td>"),
                new HtmlString("</tr>")
            };
            return l;
        }
        public static IHtmlContentContainer MyEditorForButtons<TModel>(
            this IHtmlHelper<TModel> h, string name, string? id) {
            var s = HtmlStringsForLabel(name, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStringsForLabel(string name, string? id, IPageModel? m) {
            var pageName = m?.GetType()?.Name?.Replace("Page", "");
            var l = new List<object> {
                new HtmlString($"<a href=\"/{pageName}/{name}?"),
                new HtmlString($"handler={name}&amp;"),
                new HtmlString($"id={id}&amp;"),
                new HtmlString($"order={m?.CurrentOrder}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{name}</a>")
            };
            return l;
        }
        
    }
}
