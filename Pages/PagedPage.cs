using System.ComponentModel;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc;

namespace EMEHospitalWebApp.Pages;

public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>, IPageModel, IIndexModel<TView>
    where TView : UniqueView, new()
    where TEntity : UniqueEntity
    where TRepo : IPagedRepo<TEntity> {
    protected PagedPage(TRepo r) : base(r) { }
    public int PageIndex {
        get => _repo.PageIndex; 
        set => _repo.PageIndex = value;
    }
    public int TotalPages => _repo.TotalPages;
    public bool HasNextPage => _repo.HasNextPage;
    public bool HasPreviousPage => _repo.HasPreviousPage;
    protected override void setAttributes(int idx, string? filter, string? order) {
        PageIndex = idx;
        CurrentFilter = filter;
        CurrentOrder = order;
    }
    protected override IActionResult redirectToIndex() => RedirectToPage("./Index", "Index", 
        new { pageIndex = PageIndex,
            currentFilter = CurrentFilter,
            sortOrder = CurrentOrder});
    public virtual string[] IndexColumns => Array.Empty<string>();
    public virtual object? GetValue(string name, TView v) => Safe.Run(() => {
            var pi = v?.GetType()?.GetProperty(name);
            return pi?.GetValue(v);
        });
    public string? DisplayName(string name) => Safe.Run(() => {
        var p = typeof(TView).GetProperty(name);
        var a = p?.CustomAttributes?.FirstOrDefault(x => x.AttributeType == typeof(DisplayNameAttribute));
        return a?.ConstructorArguments[0].Value?.ToString() ?? name;
    }, name);
}
