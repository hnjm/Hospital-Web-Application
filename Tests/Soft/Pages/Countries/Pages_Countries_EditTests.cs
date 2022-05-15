using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_EditTests : CountriesTests {
       [TestMethod] public async Task EditTest() => await CheckIfContains($"/Countries/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
