using System.Threading.Tasks;
using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__LoginPartialTests : SharedCRUDTests {
        [TestMethod] public async Task SharedIndexTest() {
            var pageIdx = GetRandom.Int32(1, 10);
            var html = await getHtmlPage($"/Appointments?idx={pageIdx}&handler=Index");
            isTrue(html.Contains("Find by name"));
            isTrue(html.Contains("First"));
            isTrue(html.Contains("Previous"));
            isTrue(html.Contains("Next"));
            isTrue(html.Contains("Last"));
            isTrue(html.Contains($"Page {pageIdx + 1} of total pages "));
        }
    }
}
