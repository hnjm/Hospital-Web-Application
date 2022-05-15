using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {
    [TestClass] public class Pages_Appointments_EditTests : AppointmentsTests {
        [TestMethod] public async Task EditTest() 
            => await CheckIfContains($"/Appointments/Edit?handler=Edit&id={id}&order=&idx=0&filter=", "yyyy-MM-ddTHH:mm:ss.fff");
    }
}
