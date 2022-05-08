using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_IndexTests : PagesTests<ICurrenciesRepo, Currency, CurrencyData, CurrencyView> {
        protected dynamic? c;
        [TestInitialize] public void Init() => Init(x => new Currency(x));
        protected override void Init(Func<CurrencyData, Currency> toObj) {
            base.Init(toObj);
            var cc = addItems<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(out _, ss => new CountryCurrency(ss), id);
            c = addRandomItems<ICountriesRepo, Country, CountryData>(out _, x => new Country(x), id);
        }
        private async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.Name);
            isNotNull(d.Description);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
        }
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Currencies?handler=Index");
    }
}
