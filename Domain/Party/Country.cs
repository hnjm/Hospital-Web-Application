using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party;

public interface ICountriesRepo : IRepo<Country> { }
public class Country : NamedEntity<CountryData> {
    public Country() : this(new CountryData()) { }
    public Country(CountryData d) : base(d) { }
}
