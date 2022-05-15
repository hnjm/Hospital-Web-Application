using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Countries {
    [TestClass] public class Pages_Countries_IndexTests : CountriesTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Countries?handler=Index");
    }
}
