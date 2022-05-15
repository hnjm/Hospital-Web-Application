using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_CreateTests : PatientAppointmentsTests {
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/PatientAppointments/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
