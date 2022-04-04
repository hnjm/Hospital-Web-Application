using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc;

namespace EMEHospitalWebApp.Pages;

public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : ICrudRepo<TEntity> {
    protected CrudPage(TRepo r) : base(r) { }
    protected override IActionResult getCreate() => Page();
    protected virtual async Task<IActionResult> getItemPage(string id) {
        Item = await getItem(id);
        return Item == null ? NotFound() : Page();
    }
    protected override async Task<IActionResult> getDetailsAsync(string id) => await getItemPage(id);
    protected override async Task<IActionResult> getDeleteAsync(string id) => await getItemPage(id);
    protected override async Task<IActionResult> getEditAsync(string id) => await getItemPage(id);
    protected override async Task<IActionResult> postCreateAsync() {
        if (!ModelState.IsValid) return Page();
        await _repo.AddAsync(ToObject(Item));
        return redirectToIndex();
    }
    protected override async Task<IActionResult> postDeleteAsync(string? id) {
        if (id == null) return NotFound();
        await _repo.DeleteAsync(id);
        return redirectToIndex();
    }
    protected override async Task<IActionResult> postEditAsync() {
        if (!ModelState.IsValid) return Page();
        var obj = ToObject(Item);
        var updated = await _repo.UpdateAsync(obj);
        return !updated ? NotFound() : redirectToIndex();
    }
    protected override async Task<IActionResult> getIndexAsync() {
        var list = await _repo.GetAsync();
        Items = new List<TView>();
        foreach (var obj in list) {
            var v = ToView(obj);
            Items.Add(v);
        }
        return Page();
    }
    private async Task<TView> getItem(string id)
        => ToView(await _repo.GetAsync(id));
}
