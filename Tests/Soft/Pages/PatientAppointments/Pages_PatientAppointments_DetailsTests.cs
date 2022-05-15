using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_DetailsTests : PatientAppointmentsTests {
         [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/PatientAppointments/Details?handler=Details&id={id}&order=&idx=0&filter=");
    }
}
