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
            d => d.CountryId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies);
    [TestMethod] public void CurrenciesTest() 
        => relatedItemsTest<ICurrenciesRepo, CountryCurrency, Currency, CurrencyData>
        (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Currencies, 
                x => x.CurrencyId,d => new Currency(d), 
                c => c?.Data, x => x?.Currency?.Data);
}
