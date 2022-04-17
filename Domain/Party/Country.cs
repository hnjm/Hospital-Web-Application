using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party;

public interface ICountriesRepo : IRepo<Country> { }
public class Country : NamedEntity<CountryData> {
    public Country() : this(new CountryData()) { }
    public Country(CountryData d) : base(d) { }
    public List<CountryCurrency> CountryCurrencies
        => GetRepo.Instance<ICountryCurrencyRepo>()?
            .GetAll(x => x.CountryId)?
            .Where(x => x.CountryId == Id)?
            .ToList() ?? new List<CountryCurrency>();
    public List<Currency?> Currencies => CountryCurrencies.Select(x => x.Currency).ToList();
}
