using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_CreateTests : CurrenciesTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Currencies/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
