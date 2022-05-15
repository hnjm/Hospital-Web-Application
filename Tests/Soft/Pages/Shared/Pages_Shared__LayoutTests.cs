using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__LayoutTests : SharedCRUDTests {
        [TestMethod] public async Task LayoutTest() {
            var html = await getHtmlPage("");
            isTrue(html.Contains("href=\"/Privacy\">Privacy"));
            isTrue(html.Contains("href=\"/Appointments?handler=Index\">Appointments"));
            isTrue(html.Contains("href=\"/Countries?handler=Index\">Countries"));
            isTrue(html.Contains("href=\"/CountryCurrencies?handler=Index\">Country currencies"));
            isTrue(html.Contains("href=\"/Currencies?handler=Index\">Currencies"));
            isTrue(html.Contains("href=\"/PatientAppointments?handler=Index\">Patient appointments"));
            isTrue(html.Contains("href=\"/Patients?handler=Index\">Patients"));
            isTrue(html.Contains("href=\"/Identity/Account/Register\">Register"));
            isTrue(html.Contains("href=\"/Identity/Account/Login\">Login"));
        }
    }
}
