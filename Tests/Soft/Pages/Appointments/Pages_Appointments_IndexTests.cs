using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {
    [TestClass] public class Pages_Appointments_IndexTests : PagesTests<IAppointmentRepo, Appointment, AppointmentData, AppointmentView> {
        [TestInitialize] public void Init() => Init(x => new Appointment(x));
        private async Task CheckIfContains(string url, string? format = null) {
            var html = await getHtmlPage(url);
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.Id);
            isNotNull(d.PatientsId);
            isNotNull(d.DoctorsId);
            isNotNull(d.DiagnosisId);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
        }
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Appointments?handler=Index");
    }
}
