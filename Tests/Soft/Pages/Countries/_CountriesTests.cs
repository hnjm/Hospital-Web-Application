using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class CountriesTests : PagesTests<ICountriesRepo, Country, CountryData, CountryView> {
        protected dynamic? c;
        [TestInitialize] public void Init() => Init(x => new Country(x));
        protected override void Init(Func<CountryData, Country> toObj) {
            base.Init(toObj);
            _ = addItems<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(out _, x => new CountryCurrency(x), id);
            c = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out _, x => new Currency(x), id);
        }
        protected async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(d);
            isNotNull(d.Name);
            isNotNull(d.Description);
            if (displayNameList is not null) foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (!url.Contains("Create")) {
                isTrue(html.Contains(d.Id));
                isTrue(html.Contains(d.Code));
                isTrue(html.Contains(d.Name));
                isTrue(html.Contains(d.Description));
            }
            if (url.Contains("Details") && c is not null) {
                isTrue(html.Contains(c.Name));
                isTrue(html.Contains(c.Code));
                isTrue(html.Contains(c.Description));
            }
        }
    }
}
