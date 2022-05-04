using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface ICurrenciesRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public Lazy<List<CountryCurrency>> CountryCurrencies {
            get {
                var l = GetRepo.Instance<ICountryCurrencyRepo>()?
                    .GetAll(x => x.CurrencyId)?
                    .Where(x => x.CurrencyId == Id)?
                    .ToList() ?? new List<CountryCurrency>();
                return new Lazy<List<CountryCurrency>>(l);
            }
        }
        public Lazy<List<Country?>> Countries {
            get {
                var l = CountryCurrencies.Value
                    .Select(x => x.Country)
                    .ToList();
                return new Lazy<List<Country?>>(l);
            }
        }
    }
}
