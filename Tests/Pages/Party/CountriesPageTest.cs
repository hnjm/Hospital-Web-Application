using System.Linq;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages.Party {
    [TestClass] public class CountriesPageTests : SealedBaseTests<CountriesPage, PagedPage<CountryView, Country, ICountriesRepo>> {
        protected override CountriesPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CountriesPage(new CountriesRepo(db));
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CurrenciesTest() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            HospitalDbInitializer.Init(db);
            var d = db?.Countries?.LastOrDefault();
            isNotNull(d);
            var v = new CountryViewFactory().Create(new Country(d));
            var r = GetRepo.Instance<ICountriesRepo>();
            isNotNull(r);
            var p = new CountriesPage(r) { Item = v };
            var l = p.Currencies.Value.First();
            var o = l?.CountryCurrencies.Value.First();
            isTrue(o?.CountryId == d.Id);
        }
    }
}
