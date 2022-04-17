using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMEHospitalWebApp.Pages.Party;

public class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrencyRepo> {
    private readonly ICountriesRepo country;
    private readonly ICurrenciesRepo currency;
    public CountryCurrenciesPage(ICountryCurrencyRepo r, ICountriesRepo co, ICurrenciesRepo cu) : base(r) {
        country = co;
        currency = cu;
    }
    protected override CountryCurrency ToObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);
    protected override CountryCurrencyView ToView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = {
        nameof(CountryCurrencyView.Code),
        nameof(CountryCurrencyView.Name),
        nameof(CountryCurrencyView.CountryId),
        nameof(CountryCurrencyView.CurrencyId),
        nameof(CountryCurrencyView.Description)
    };
    public IEnumerable<SelectListItem> Countries
        => country?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
    public IEnumerable<SelectListItem> Currencies
        => currency?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
    public string CountryName(string? countryId = null)
        => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Undefined";
    public string CurrencyName(string? currencyId = null)
        => Currencies?.FirstOrDefault(x => x.Value == (currencyId ?? string.Empty))?.Text ?? "Undefined";
    public override object? GetValue(string name, CountryCurrencyView v) {
        var r = base.GetValue(name, v);
        return name == nameof(CountryCurrencyView.CountryId) ? CountryName(r as string)
            : name == nameof(CountryCurrencyView.CurrencyId) ? CurrencyName(r as string)
            : r;
    }
}
