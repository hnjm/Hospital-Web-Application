using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class PatientAppointmentsTests : PagesTests<IPatientAppointmentRepo, PatientAppointment, PatientAppointmentData, PatientAppointmentView> {
        [TestInitialize] public void Init() => Init(x => new PatientAppointment(x));
        protected async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(d);
            isNotNull(d.AppointmentId);
            isNotNull(d.PatientId);
            isNotNull(d.Name);
            isNotNull(d.Code);
            isNotNull(d.Description);
            if (displayNameList is not null) foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (!url.Contains("Create")) {
                isTrue(html.Contains(d.Id));
                //isTrue(html.Contains(d.AppointmentId)); TODO
                //isTrue(html.Contains(d.PatientId)); TODO
                isTrue(html.Contains(d.Name));
                isTrue(html.Contains(d.Code));
                isTrue(html.Contains(d.Description));
            }
        }
    }
}
