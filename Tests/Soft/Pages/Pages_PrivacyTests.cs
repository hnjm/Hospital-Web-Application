using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_PrivacyTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
        [TestMethod] public async Task PrivacyTest() {
            var html = await getHtmlPage("/Privacy");
            isNotNull(html);
            isTrue(html.Contains("Privacy Policy"));
        }
    }
}
