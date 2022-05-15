using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_ErrorTests : IndexTests {
        [TestMethod] public async Task DevErrorTest() {
            var html = await getHtmlPage("/Currencies", clientProduction);
            isTrue(html.Contains("An error occurred while processing your request."));
        }
        [TestMethod] public async Task ProductionErrorTest() {
            var html = await getHtmlPage("/Currencies", clientDevelopment);
            isTrue(html.Contains("System.ArgumentNullException"));
        }
    }
}
