using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party;

public interface ICountryCurrencyRepo : IRepo<CountryCurrency> { }
public sealed class CountryCurrency : NamedEntity<CountryCurrencyData> {
    public CountryCurrency() : this(new CountryCurrencyData()) { }
    public CountryCurrency(CountryCurrencyData d) : base(d) { }
    public string CountryId => getValue(Data?.CountryId);
    public string CurrencyId => getValue(Data?.CurrencyId);
    public Country? Country => GetRepo.Instance<ICountriesRepo>()?.Get(CountryId);
    public Currency? Currency => GetRepo.Instance<ICurrenciesRepo>()?.Get(CurrencyId);
}
