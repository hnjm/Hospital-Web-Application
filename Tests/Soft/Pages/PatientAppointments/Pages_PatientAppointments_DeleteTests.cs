using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_DeleteTests : PatientAppointmentsTests {
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/PatientAppointments/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
