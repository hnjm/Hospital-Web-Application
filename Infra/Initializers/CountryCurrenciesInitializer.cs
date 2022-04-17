using System.Globalization;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;

namespace EMEHospitalWebApp.Infra.Initializers;

public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
    public CountryCurrenciesInitializer(HospitalWebAppDb? db) : base(db, db?.CountryCurrency) { }
    protected override IEnumerable<CountryCurrencyData> getEntities {
        get {
            var l = new List<CountryCurrencyData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var countryId = c.ThreeLetterISORegionName;
                var currencyId = c.ISOCurrencySymbol;
                var nativeName = c.CurrencyNativeName;
                var currencyCode = c.CurrencySymbol;
                var d = createEntity(countryId, currencyId, currencyCode, nativeName);
                l.Add(d);
            }
            return l;
        }
    }
    internal CountryCurrencyData createEntity(string countryId, string currencyId, string code, string? name = null, string? description = null)
        => new() {
            Id = UniqueData.NewId, 
            CountryId = countryId, 
            CurrencyId = currencyId, 
            Code = code ?? UniqueEntity.DefaultSrt, 
            Name = name, 
            Description = description
        };
}
