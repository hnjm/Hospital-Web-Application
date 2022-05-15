using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class Pages_CountryCurrencies_EditTests : CountryCurrenciesTests {
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/CountryCurrencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
