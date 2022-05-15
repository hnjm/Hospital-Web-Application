using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_DetailsTests : CountriesTests {
        [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
    }
}
