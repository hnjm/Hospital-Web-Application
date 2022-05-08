using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_ErrorTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
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
