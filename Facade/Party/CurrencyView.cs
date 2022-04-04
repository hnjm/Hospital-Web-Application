using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party;

public sealed class CurrencyView : IsoNamedView {}

public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
    protected override Currency ToEntity(CurrencyData d) => new(d);
}
