using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {
    [TestClass] public class Pages_Appointments_DeleteTests : AppointmentsTests {
        [TestMethod] public async Task DeleteTest() 
            => await CheckIfContains($"/Appointments/Delete?handler=Delete&id={id}&order=&idx=0&filter=", "dd.MM.yyyy HH:mm:ss");
    }
}
