using System.Text.Json;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc;

namespace EMEHospitalWebApp.Pages;

public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
    where TView : UniqueView, new()
    where TEntity : UniqueEntity
    where TRepo : ICrudRepo<TEntity> {
    protected CrudPage(TRepo r) : base(r) { }
    protected override IActionResult getCreate() => Page();
    protected virtual async Task<IActionResult> getItemPage(string id) {
        Item = await getItem(id);
        return itemPage();
    }
    protected IActionResult itemPage() => Item == null ? NotFound() : Page();
    protected override async Task<IActionResult> getDetailsAsync(string id) => await getItemPage(id);
    protected override async Task<IActionResult> getDeleteAsync(string id) {
        ErrorMessage = TempData["Error"] as string;
        return await getItemPage(id);
    }
    protected override async Task<IActionResult> getEditAsync(string id) {
        var s = TempData["Item"] as string;
        TView? v = null;
        if (s is not null) v = JsonSerializer.Deserialize<TView>(s);
        if (v is null) return await getItemPage(id);
        return await getEditAsync(v);
    }
    protected async Task<IActionResult> getEditAsync(TView v) {
        Item = await getItem(v.Id);
        ModelState.AddModelError(string.Empty, 
            "The record you attempted to edit was modified by another user after you. The "
            + "edit operation was canceled and the current values in the database "
            + "have been displayed. If you still want to edit this record, click "
            + "the Save button again.");
        foreach (var p in Item.GetType().GetProperties()) {
            var n = p.Name;
            var currentValue = p.GetValue(Item)?.ToString();
            var clientValue = v?.GetType()?.GetProperty(n)?.GetValue(v)?.ToString();
            if (currentValue != clientValue)
                ModelState.AddModelError(
                    $"{nameof(Item)}.{n}",
                    $"Your value: {clientValue}");
        }
        return itemPage();
    }
    protected override async Task<IActionResult> postCreateAsync() {
        if (!ModelState.IsValid) return Page();
        await _repo.AddAsync(ToObject(Item));
        return redirectToIndex();
    }
    protected override async Task<IActionResult> postDeleteAsync(string id, string? token = null) {
        if (id == null) return redirectToIndex();
        var o = await getItem(id);
        if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) return redirectToIndex();
        var oToken = ConcurrencyToken.ToStr(o.Token);
        if (oToken != token) return redirectToDelete(id);
        await _repo.DeleteAsync(id);
        return redirectToIndex();
    }
    protected override async Task<IActionResult> postEditAsync() {
        var o = await _repo.GetAsync(Item.Id);
        if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) {
            ModelState.AddModelError(string.Empty, "Unable to save. The item was deleted by another user.");
            return Page();
        }
        var oToken = ConcurrencyToken.ToStr(o.Token);
        var itemToken = ConcurrencyToken.ToStr(Item.Token);
        if (oToken != itemToken) return redirectToEdit(Item);
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
