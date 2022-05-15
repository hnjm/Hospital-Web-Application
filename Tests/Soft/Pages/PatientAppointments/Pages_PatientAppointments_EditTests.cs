using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_EditTests : PatientAppointmentsTests {
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/PatientAppointments/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
