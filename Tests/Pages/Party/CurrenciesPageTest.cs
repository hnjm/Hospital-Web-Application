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
    [TestClass] public class CurrenciesPageTests : SealedBaseTests<CurrenciesPage, PagedPage<CurrencyView, Currency, ICurrenciesRepo>> {
        protected override CurrenciesPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CurrenciesPage(new CurrenciesRepo(db));
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountriesTest() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            HospitalDbInitializer.Init(db);
            var d = db?.Currencies?.LastOrDefault();
            isNotNull(d);
            var v = new CurrencyViewFactory().Create(new Currency(d));
            var r = GetRepo.Instance<ICurrenciesRepo>();
            isNotNull(r);
            var p = new CurrenciesPage(r) { Item = v };
            var l = p.Countries.Value.First();
            var o = l?.CountryCurrencies.Value.First();
            isTrue(o?.CurrencyId == d.Id);
        }
    }
}
