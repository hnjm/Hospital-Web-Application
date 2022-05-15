using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class SharedCRUDTests : IndexTests {
        protected async Task CheckIfContains(string url, string? format = null) {
            var html = await getHtmlPage(url);
            var crudName = url.Split("?handler=")[0].Replace("/Appointments/", "");
            isTrue(html.Contains($"<h1>{crudName}</h1>"));
            isTrue(html.Contains("<h4>Appointments</h4>"));
        }
    }
}
