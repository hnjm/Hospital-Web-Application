using System.Net;
using System.Threading.Tasks;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft {
    public class PagesTests : HostTests {

    }
    [TestClass] public class IndexPagesTests : PagesTests {
        [TestMethod] public async Task GetCountriesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
            var page = await client.GetAsync("/Countries?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h4>Countries</h4>"));
        }
        [TestMethod] public async Task GetCurrenciesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
            var page = await client.GetAsync("/Currencies?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h4>Currencies</h4>"));
        }
        [TestMethod] public async Task GetAppointmentsIndexPageTest() {
            var page = await client.GetAsync("/Appointments?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Log in</h1>"));
        }
        [TestMethod] public async Task GetCountriesDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            var page = await client.GetAsync($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isNotNull(d);
            isNotNull(d.Name);
            isNotNull(d.Description);
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Description));
        }
    }
}
