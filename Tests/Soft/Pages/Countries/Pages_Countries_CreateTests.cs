using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_CreateTests : CountriesTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Countries/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
