using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class Pages_CountryCurrencies_CreateTests : CountryCurrenciesTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/CountryCurrencies/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
