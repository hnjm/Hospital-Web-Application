using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Pages;

public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
    where TView : UniqueView, new()
    where TEntity : UniqueEntity
    where TRepo : IFilteredRepo<TEntity> {
    protected FilteredPage(TRepo r) : base(r) { }
    public string? CurrentFilter {
        get => _repo.CurrentFilter;
        set => _repo.CurrentFilter = value;
    }
}
