using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party;

[TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
    [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
    [TestMethod] public void CurrencyIdTest() => isReadOnly(obj.Data.CurrencyId);
    [TestMethod] public void CountryTest() => itemTest<ICountriesRepo, Country, CountryData>(
        obj.CountryId, d => new Country(d), () => obj.Country);
    [TestMethod] public void CurrencyTest() => itemTest<ICurrenciesRepo, Currency, CurrencyData>(
        obj.CurrencyId, d => new Currency(d), () => obj.Currency);
}
