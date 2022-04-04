using EMEHospitalWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra.Initializers;

public abstract class BaseInitializer<TData> where TData : UniqueData{
    protected internal DbContext? db;
    protected internal DbSet<TData>? set;
    protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
        db = c;
        set = s;
    }
    public void Init() {
        if (set?.Any() ?? true) return;
        set.AddRange(getEntities);
        db?.SaveChanges();
    }
    protected abstract IEnumerable<TData> getEntities { get; }
    internal bool isCorrectIsoCode(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
}

public static class HospitalDbInitializer {
    public static void Init(HospitalWebAppDb? db) {
        new AppointmentsInitializer(db).Init();
        new PatientsInitializer(db).Init();
        new CountryInitializer(db).Init();
        new CurrencyInitializer(db).Init();
    }
}
