using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_DeleteTests : PagesTests<IPatientAppointmentRepo, PatientAppointment, PatientAppointmentData, PatientAppointmentView> {
        [TestInitialize] public void Init() => Init(x => new PatientAppointment(x));
        private async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.Id);
            isNotNull(d.AppointmentId);
            isNotNull(d.PatientId);
            isNotNull(d.Name);
            isNotNull(d.Code);
            isNotNull(d.Description);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
            isTrue(html.Contains(d.Id));
            //isTrue(html.Contains(d.AppointmentId)); TODO
            //isTrue(html.Contains(d.PatientId)); TODO
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
        }
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/PatientAppointments/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
