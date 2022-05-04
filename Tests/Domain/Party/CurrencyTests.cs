using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party;

[TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
    protected override Currency createObj() => new Currency(GetRandom.Value<CurrencyData>());
    [TestMethod] public void CountryCurrenciesTest()
        => itemsTest<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(
            d => d.CurrencyId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies.Value);
    [TestMethod] public void CountriesTest()
        => relatedItemsTest<ICountriesRepo, CountryCurrency, Country, CountryData>
        (CountryCurrenciesTest, () => obj.CountryCurrencies.Value, () => obj.Countries.Value,
            x => x.CountryId, d => new Country(d),
            c => c?.Data, x => x?.Country?.Data);
}
