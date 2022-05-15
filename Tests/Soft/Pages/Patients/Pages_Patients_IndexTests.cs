using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_IndexTests : PatientsTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Patients?handler=Index");
    }
}
