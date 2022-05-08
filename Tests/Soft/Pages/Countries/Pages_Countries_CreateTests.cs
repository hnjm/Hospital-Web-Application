using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_CreateTests : PagesTests<ICountriesRepo, Country, CountryData, CountryView> {
        protected dynamic? c;
        [TestInitialize] public void Init() => Init(x => new Country(x));
        protected override void Init(Func<CountryData, Country> toObj) {
            base.Init(toObj);
            var cc = addItems<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(out _, x => new CountryCurrency(x), id);
            c = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out _, x => new Currency(x), id);
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
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Countries/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
