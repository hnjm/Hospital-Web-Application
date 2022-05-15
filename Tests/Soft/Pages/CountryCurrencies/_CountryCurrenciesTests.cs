using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class CountryCurrenciesTests : PagesTests<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData, CountryCurrencyView> {
        [TestInitialize] public void Init() => Init(x => new CountryCurrency(x));
        protected async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(d);
            isNotNull(d.CountryId);
            isNotNull(d.CurrencyId);
            isNotNull(d.Name);
            isNotNull(d.Code);
            isNotNull(d.Description);
            if (displayNameList is not null) foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (!url.Contains("Create")) {
                isTrue(html.Contains(d.Id));
                //isTrue(html.Contains(d.CountryId)); TODO
                //isTrue(html.Contains(d.CurrencyId)); TODO
                isTrue(html.Contains(d.Name));
                isTrue(html.Contains(d.Code));
                isTrue(html.Contains(d.Description));
            }
        }
    }
}
