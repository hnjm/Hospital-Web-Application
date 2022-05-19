using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface ICountriesRepo : IRepo<Country> { }
    public sealed class Country : NamedEntity<CountryData>, IComparable {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
        public Lazy<List<CountryCurrency>> CountryCurrencies {
            get {
                var l = GetRepo.Instance<ICountryCurrencyRepo>()?
                    .GetAll(x => x.CountryId)?
                    .Where(x => x.CountryId == Id)?
                    .ToList() ?? new List<CountryCurrency>();
                return new Lazy<List<CountryCurrency>>(l);
            }
        }
        public Lazy<List<Currency?>> Currencies {
            get {
                var l = CountryCurrencies.Value
                    .Select(x => x.Currency)
                    .ToList();
                return new Lazy<List<Currency?>>(l);
            }
        }
        public int CompareTo(object? x) => compareTo(x as Country);
        private int compareTo(Country? c) => Name.CompareTo(c?.Name);
    }
}
