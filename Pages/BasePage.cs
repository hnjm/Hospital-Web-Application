using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMEHospitalWebApp.Pages;
public abstract class BasePage<TView, TEntity, TRepo> : PageModel 
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IBaseRepo<TEntity> {

    protected readonly TRepo _repo;
    protected abstract TView ToView(TEntity? entity);
    protected abstract TEntity ToObject(TView? item);
    protected abstract IActionResult redirectToIndex();
    [BindProperty] public TView? Item { get; set; }
    public IList<TView>? Items { get; set; }
    public string ItemId => Item?.Id ?? string.Empty;
    protected BasePage(TRepo r) => _repo = r;
    protected abstract IActionResult getCreate();
    protected abstract void setAttributes(int idx, string? filter, string? order);
    protected virtual async Task<IActionResult> perform(Func<Task<IActionResult>>f, 
        int idx, string? filter, string? order, bool removeKeys = false) {
        setAttributes(idx, filter, order);
        if (removeKeys) removeKey(nameof(filter), nameof(order));
        return await f();
    }
    protected abstract Task<IActionResult> postCreateAsync();
    protected abstract Task<IActionResult> getDetailsAsync(string id);
    protected abstract Task<IActionResult> getDeleteAsync(string id);
    protected abstract Task<IActionResult> postDeleteAsync(string? id);
    protected abstract Task<IActionResult> getEditAsync(string id);
    protected abstract Task<IActionResult> postEditAsync();
    protected abstract Task<IActionResult> getIndexAsync();
    internal virtual void removeKey(params string[] keys) {
        foreach (var key in keys) {
            Safe.Run(() => ModelState.Remove(key));
        }
    }
    public IActionResult OnGetCreate(int idx = 0, string? filter = null, string? order = null) {
        setAttributes(idx, filter, order);
        return getCreate();
    }
    public async Task<IActionResult> OnPostCreateAsync(int idx = 0, string? filter = null, string? order = null)
        => await perform(postCreateAsync, idx, filter, order, true);
    public async Task<IActionResult> OnGetDetailsAsync(string id, int idx = 0, string? filter = null, string? order = null) 
        => await perform(() => getDetailsAsync(id), idx, filter, order);
    public async Task<IActionResult> OnGetDeleteAsync(string id, int idx = 0, string? filter = null, string? order = null)
        => await perform(() => getDeleteAsync(id), idx, filter, order);
    public async Task<IActionResult> OnPostDeleteAsync(string? id, int idx = 0, string? filter = null, string? order = null)
        => await perform(() => postDeleteAsync(id), idx, filter, order);
    public async Task<IActionResult> OnGetEditAsync(string id, int idx = 0, string? filter = null, string? order = null)
        => await perform(() => getEditAsync(id), idx, filter, order);
    public async Task<IActionResult> OnPostEditAsync(int idx = 0, string? filter = null, string? order = null)
        => await perform(postEditAsync, idx, filter, order, true);
    public async Task<IActionResult> OnGetIndexAsync(int idx = 0, string? filter = null, string? order = null)
        => await perform(getIndexAsync, idx, filter, order, true);
}
