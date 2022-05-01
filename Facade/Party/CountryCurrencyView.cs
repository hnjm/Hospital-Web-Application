using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party;

public class CountryCurrencyView : NamedView {
    [DisplayName("Country")][Required] public string CountryId { get; set; } = string.Empty;
    [DisplayName("Currency")][Required] public string CurrencyId { get; set; } = string.Empty;
    [DisplayName("Currency native code")] public new string? Code { get; set; }
    [DisplayName("Currency native name")] public new string? Name { get; set; }
}

public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
    protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);
}
