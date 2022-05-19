using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party;

[TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>>{
    protected override Country createObj() => new Country(GetRandom.Value<CountryData>());
    [TestMethod] public void CountryCurrenciesTest()
        => itemsTest<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(
            d => d.CountryId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies.Value);
    [TestMethod] public void CurrenciesTest()
        => relatedItemsTest<ICurrenciesRepo, CountryCurrency, Currency, CurrencyData>
        (CountryCurrenciesTest, () => obj.CountryCurrencies.Value, () => obj.Currencies.Value,
                x => x.CurrencyId, d => new Currency(d),
                c => c?.Data, x => x?.Currency?.Data);
    [TestMethod] public void CompareToTest() {
        var dX = GetRandom.Value<CountryData>() as CountryData;
        var dY = GetRandom.Value<CountryData>() as CountryData;
        isNotNull(dX);
        isNotNull(dY);
        var expected = dX.Name?.CompareTo(dY.Name);
        areEqual(expected, new Country(dX).CompareTo(new Country(dY)));
    }
}
