using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party;

public class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo {
    public CountriesRepo(HospitalWebAppDb? db) : base(db, db?.Countries) { }
    protected override Country ToDomain(CountryData d) => new(d);
    internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q : q.Where(
            x => x.Code.Contains(y)
                 || x.Name.Contains(y) 
                 || x.Id.Contains(y)
                 || x.Description.Contains(y));
    }
}
