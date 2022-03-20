using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMEHospitalWebApp.Pages;

public abstract class BasePage<TView, TEntity, TRepo> : PageModel 
    where TView : BaseView
    where TEntity : Entity
    where TRepo : IBaseRepo<TEntity> {

    private readonly TRepo _repo;
    protected abstract TView ToView(TEntity? entity);
    protected abstract TEntity ToObject(TView? item);

    [BindProperty] public TView? Item { get; set; }
    public IList<TView>? Items { get; set; }

    public string ItemId => Item?.Id ?? string.Empty;
    public BasePage(TRepo r) => _repo = r;

    public IActionResult OnGetCreate() => Page();
    public async Task<IActionResult> OnPostCreateAsync() {
        if (!ModelState.IsValid) return Page();
        await _repo.AddAsync(ToObject(Item));
        return RedirectToPage("./Index", "Index");
    }
    public async Task<IActionResult> OnGetDetailsAsync(string id) {
        Item = await GetItem(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnGetDeleteAsync(string id) {
        Item = await GetItem(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostDeleteAsync(string? id) {
        if (id == null) return NotFound();
        await _repo.DeleteAsync(id);
        return RedirectToPage("./Index", "Index");
    }
    public async Task<IActionResult> OnGetEditAsync(string id) {
        Item = await GetItem(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostEditAsync() {
        if (!ModelState.IsValid) return Page();
        var obj = ToObject(Item);
        var updated = await _repo.UpdateAsync(obj);
        if (!updated) return NotFound();
        return RedirectToPage("./Index", "Index");
    }
    public async Task<IActionResult> OnGetIndexAsync() {
        var list = await _repo.GetAsync();
        Items = new List<TView>();
        foreach (var obj in list) {
            var v = ToView(obj);
            Items.Add(v);
        }
        return Page();
    }
    private async Task<TView> GetItem(string id)
        => ToView(await _repo.GetAsync(id));
}
