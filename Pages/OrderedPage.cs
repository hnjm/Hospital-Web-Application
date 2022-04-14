using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Pages;

public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
    where TView : UniqueView, new()
    where TEntity : UniqueEntity
    where TRepo : IOrderedRepo<TEntity> {
    protected OrderedPage(TRepo r) : base(r) { }
    public string? CurrentOrder {
        get => _repo.CurrentOrder;
        set => _repo.CurrentOrder = value;
    }
}
