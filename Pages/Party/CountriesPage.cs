using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;

namespace EMEHospitalWebApp.Pages.Party;

public class CountriesPage : PagedPage<CountryView, Country, ICountriesRepo> {
    public CountriesPage(ICountriesRepo r) : base(r) { }
    protected override Country ToObject(CountryView? item) => new CountryViewFactory().Create(item);
    protected override CountryView ToView(Country? entity) => new CountryViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = {
        nameof(CountryView.Code),
        nameof(CountryView.Name),
        nameof(CountryView.Description),
    };
}
