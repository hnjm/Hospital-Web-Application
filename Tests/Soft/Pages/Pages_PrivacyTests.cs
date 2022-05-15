using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_PrivacyTests : IndexTests {
        [TestMethod] public async Task PrivacyTest() {
            var html = await getHtmlPage("/Privacy");
            isTrue(html.Contains("Privacy Policy"));
        }
    }
}
