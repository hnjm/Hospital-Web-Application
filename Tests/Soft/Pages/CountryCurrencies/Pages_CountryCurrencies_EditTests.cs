using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class Pages_CountryCurrencies_EditTests : PagesTests<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData, CountryCurrencyView> {
        [TestInitialize] public void Init() => Init(x => new CountryCurrency(x));
        private async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.Id);
            isNotNull(d.CountryId);
            isNotNull(d.CurrencyId);
            isNotNull(d.Name);
            isNotNull(d.Code);
            isNotNull(d.Description);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
            isTrue(html.Contains(d.Id));
            //isTrue(html.Contains(d.CountryId)); TODO
            //isTrue(html.Contains(d.CurrencyId)); TODO
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
        }
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/CountryCurrencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
