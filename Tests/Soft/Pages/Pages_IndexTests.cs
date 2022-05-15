using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_IndexTests : IndexTests {
        [TestMethod] public async Task HomeIndexTest() {
            var html = await getHtmlPage("");
            isTrue(html.Contains("Holgeri ning Eliise veebirakendus"));
        }
    }
}
