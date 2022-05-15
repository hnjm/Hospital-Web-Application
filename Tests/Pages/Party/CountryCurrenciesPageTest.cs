using System.Linq;
using EMEHospitalWebApp.Data.Party;
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
    [TestClass] public class CountryCurrenciesPageTests 
        : SealedBaseTests<CountryCurrenciesPage, PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrencyRepo>> {
        protected override CountryCurrenciesPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CountryCurrenciesPage(new CountryCurrenciesRepo(db), new CountriesRepo(db), new CurrenciesRepo(db));
        }
        private HospitalWebAppDb? db;
        private CountryCurrenciesPage? p;
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            p = new CountryCurrenciesPage(new CountryCurrenciesRepo(db), new CountriesRepo(db), new CurrenciesRepo(db));
            HospitalDbInitializer.Init(db);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountryNameTest() {
            var d = db?.Countries?.FirstOrDefault();
            var cn = p?.CountryName(d?.Id);
            areEqual(d?.Name, cn);
        }
        [TestMethod] public void CurrencyNameTest() {
            var d = db?.Currencies?.FirstOrDefault();
            var cn = p?.CurrencyName(d?.Id);
            areEqual(d?.Name, cn);
        }
        [TestMethod] public void GetValueTest() {
            var d = new CountryCurrencyData() { CurrencyId = "EUR", CountryId = "EST" };
            var v = new CountryCurrencyViewFactory().Create(new CountryCurrency(d));
            var o = p?.GetValue(nameof(d.CurrencyId), v);
            areEqual("Euro", o);
            o = p?.GetValue(nameof(d.CountryId), v);
            areEqual("Estonia", o);
        }
        [TestMethod] public void CountriesTest() 
            => areEqual(db?.Countries?.Count(), p?.Countries?.Count());
        [TestMethod] public void CurrenciesTest() 
            => areEqual(db?.Currencies?.Count(), p?.Currencies?.Count());
    }
}
