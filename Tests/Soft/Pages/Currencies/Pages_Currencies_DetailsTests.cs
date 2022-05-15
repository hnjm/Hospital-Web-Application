using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Currencies {
    [TestClass] public class Pages_Currencies_DetailsTests : CurrenciesTests {
       [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/Currencies/Details?handler=Details&id={id}&order=&idx=0&filter=");
    }
}
