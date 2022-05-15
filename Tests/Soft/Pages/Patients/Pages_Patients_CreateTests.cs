using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_CreateTests : PatientsTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Patients/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
