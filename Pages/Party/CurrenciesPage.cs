using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;

namespace EMEHospitalWebApp.Pages.Party;

public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrenciesRepo> {
    public CurrenciesPage(ICurrenciesRepo r) : base(r) { }
    protected override Currency ToObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
    protected override CurrencyView ToView(Currency? entity) => new CurrencyViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = {
        nameof(CurrencyView.Code),
        nameof(CurrencyView.Name),
        nameof(CurrencyView.Description),
    };
    public List<Country?> Countries => ToObject(Item).Countries;
}
