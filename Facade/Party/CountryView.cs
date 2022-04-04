using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party;

public sealed class CountryView : IsoNamedView {}

public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData> {
    protected override Country ToEntity(CountryData d) => new(d);
}
