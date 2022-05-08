using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.PatientAppointments {
    [TestClass] public class Pages_PatientAppointments_CreateTests : PagesTests<IPatientAppointmentRepo, PatientAppointment, PatientAppointmentData, PatientAppointmentView> {
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
        }
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/PatientAppointments/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
