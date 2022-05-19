using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Appointments {

    [TestClass] public class AppointmentsTests : PagesTests<IAppointmentRepo, Appointment, AppointmentData, AppointmentView> {
        [TestInitialize] public void Init() => Init(x => new Appointment(x));
        protected async Task CheckIfContains(string url, string? format = null) {
            var html = await getHtmlPage(url);
            isNotNull(d);
            isNotNull(d.PatientsId);
            isNotNull(d.DoctorsId);
            isNotNull(d.DiagnosisId);
            if (displayNameList is not null) foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (!url.Contains("Create")) {
                isTrue(html.Contains(d.Id));
                isTrue(html.Contains(d.PatientsId));
                isTrue(html.Contains(d.DoctorsId));
                isTrue(html.Contains(d.DateTime.Value.ToString(format)));
                isTrue(html.Contains(d.DiagnosisId));
            }
        }
    }
}
