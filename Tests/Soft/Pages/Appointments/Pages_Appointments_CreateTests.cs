using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {
    [TestClass] public class Pages_Appointments_CreateTests : AppointmentsTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Appointments/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
