using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_DeleteTests : CurrenciesTests {
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/Currencies/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
