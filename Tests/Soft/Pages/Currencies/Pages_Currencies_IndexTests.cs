using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_IndexTests : CurrenciesTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Currencies?handler=Index");
    }
}
