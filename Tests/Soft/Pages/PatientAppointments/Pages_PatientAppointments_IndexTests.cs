using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_IndexTests : PatientAppointmentsTests {
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/PatientAppointments?handler=Index");
    }
}
