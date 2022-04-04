using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party;

public class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
    public CurrenciesRepo(HospitalWebAppDb? db) : base(db, db?.Currencies) { }
    protected override Currency ToDomain(CurrencyData d) => new Currency(d);
    internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q) {
        var y = CurrentFilter;
        if (string.IsNullOrWhiteSpace(y)) return q;
        return q.Where(
            x => x.Code.Contains(y)
                 || x.Name.Contains(y)
                 || x.Id.Contains(y)
                 || x.Description.Contains(y));
    }
}
