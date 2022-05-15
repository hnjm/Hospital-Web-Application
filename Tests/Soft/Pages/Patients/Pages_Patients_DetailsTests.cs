using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_DetailsTests : PatientsTests {
        [TestMethod] public async Task DetailsTest() 
            => await CheckIfContains($"/Patients/Details?handler=Details&id={id}&order=&idx=0&filter=", "dd.MM.yyyy HH:mm:ss");
    }
}
