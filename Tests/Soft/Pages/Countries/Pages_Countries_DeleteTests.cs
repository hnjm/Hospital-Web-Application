using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_DeleteTests : CountriesTests {
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/Countries/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
