using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class Pages_CountryCurrencies_IndexTests : CountryCurrenciesTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/CountryCurrencies?handler=Index");
    }
}
