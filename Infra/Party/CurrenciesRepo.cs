using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party;

public class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo {
    public CurrenciesRepo(HospitalWebAppDb? db) : base(db, db?.Currencies) { }
    protected override Currency ToDomain(CurrencyData d) => new(d);
    internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q : q.Where(
            x => contains(x.Code, y)
                 || contains(x.Name, y)
                 || contains(x.Id, y)
                 || contains(x.Description, y));
    }
}
