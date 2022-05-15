using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {
    [TestClass] public class Pages_Appointments_IndexTests : AppointmentsTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Appointments?handler=Index");
    }
}
