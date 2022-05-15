using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_EditTests : CurrenciesTests {
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/Currencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
