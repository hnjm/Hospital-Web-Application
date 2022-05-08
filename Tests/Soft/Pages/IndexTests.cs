using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class IndexTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
        [TestMethod] public async Task IndexTest() {
            var html = await getHtmlPage("");
            isNotNull(html);
            isTrue(html.Contains("Holgeri ning Eliise veebirakendus"));
        }
        [TestMethod] public async Task PrivacyTest() {
            var html = await getHtmlPage("/Privacy");
            isNotNull(html);
            isTrue(html.Contains("Privacy Policy"));
        }
        [TestMethod] public async Task RegisterTest() {
            var html = await getHtmlPage("/Identity/Account/Register");
            isNotNull(html);
            isTrue(html.Contains("Create a new account."));
        }
        [TestMethod] public async Task LoginTest() {
            var html = await getHtmlPage("/Identity/Account/Login");
            isNotNull(html);
            isTrue(html.Contains("Use a local account to log in."));
        }
        //[TestMethod] public async Task LoginTest2() { TODO
        //    var html = await getHtmlPage("/Identity/Account/Manage", clientTest);
        //    isNotNull(html);
        //    //isTrue(html.Contains("Use a local account to log in."));
        //}
        [TestMethod] public async Task DevErrorTest() {
            var html = await getHtmlPage("/Currencies", clientProduction);
            isNotNull(html);
            isTrue(html.Contains("An error occurred while processing your request."));
        }
        [TestMethod] public async Task ProductionErrorTest() {
            var html = await getHtmlPage("/Currencies", clientDevelopment);
            isNotNull(html);
            isTrue(html.Contains("System.ArgumentNullException"));
        }
    }
}
