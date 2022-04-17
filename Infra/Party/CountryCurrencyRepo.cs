using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party;

public class CountryCurrencyRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrencyRepo {
    public CountryCurrencyRepo(HospitalWebAppDb? db) : base(db, db?.CountryCurrency) { }
    protected override CountryCurrency ToDomain(CountryCurrencyData d) => new(d);
    internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => x.Id.Contains(y)
                     || x.Code.Contains(y)
                     || x.Name.Contains(y) 
                     || x.CountryId.Contains(y)
                     || x.CurrencyId.Contains(y));
    }
}
