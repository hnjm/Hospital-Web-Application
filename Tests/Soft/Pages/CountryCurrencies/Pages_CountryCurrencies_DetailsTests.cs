using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class Pages_CountryCurrencies_DetailsTests : CountryCurrenciesTests {
        [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/CountryCurrencies/Details?handler=Details&id={id}&order=&idx=0&filter=");
    }
}
