using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_DeleteTests : PatientsTests {
        [TestMethod] public async Task DeleteTest() 
            => await CheckIfContains($"/Patients/Delete?handler=Delete&id={id}&order=&idx=0&filter=", "dd.MM.yyyy HH:mm:ss");
    }
}
