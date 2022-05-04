using System.Globalization;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;

namespace EMEHospitalWebApp.Infra.Initializers;

public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData> {
    public CurrenciesInitializer(HospitalWebAppDb? db) : base(db, db?.Currencies) { }
    protected override IEnumerable<CurrencyData> getEntities {
        get {
            var l = new List<CurrencyData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var id = c.ISOCurrencySymbol;
                if (!isCorrectIsoCode(id)) continue;
                if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                var d = createCountry(id, c.CurrencyEnglishName, c.CurrencyNativeName);
                l.Add(d);
            }
            return l;
        }
    }
    internal CurrencyData createCountry(string code, string name, string description) 
        => new() { Id = code ?? UniqueData.NewId, Code = code ?? UniqueEntity.DefaultSrt, Name = name, Description = description };
}
