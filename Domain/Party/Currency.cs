using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party;

public interface ICurrenciesRepo : IRepo<Currency> { }
public sealed class Currency : NamedEntity<CurrencyData> {
    public Currency() : this(new CurrencyData()) { }
    public Currency(CurrencyData d) : base(d) { }
    public List<CountryCurrency> CountryCurrencies
        => GetRepo.Instance<ICountryCurrencyRepo>()?
            .GetAll(x => x.CurrencyId)?
            .Where(x => x.CurrencyId == Id)?
            .ToList() ?? new List<CountryCurrency>();
    public List<Country?> Countries 
        => CountryCurrencies
            .Select(x => x.Country)
            .ToList();
}
