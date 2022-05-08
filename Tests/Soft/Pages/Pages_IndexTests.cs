using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages_IndexTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
        [TestMethod] public async Task IndexTest() {
            var html = await getHtmlPage("");
            isNotNull(html);
            isTrue(html.Contains("Holgeri ning Eliise veebirakendus"));
        }
    }
}
