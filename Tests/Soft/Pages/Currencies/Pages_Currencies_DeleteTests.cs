using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_DeleteTests : PagesTests<ICurrenciesRepo, Currency, CurrencyData, CurrencyView> {
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
            isTrue(html.Contains(d.Id));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Description));
        }
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/Currencies/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
