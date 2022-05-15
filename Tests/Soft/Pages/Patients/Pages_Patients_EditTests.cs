using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_EditTests : PatientsTests {
        [TestMethod] public async Task EditTest() 
            => await CheckIfContains($"/Patients/Edit?handler=Edit&id={id}&order=&idx=0&filter=", "yyyy-MM-ddTHH:mm:ss.fff");
    }
}
