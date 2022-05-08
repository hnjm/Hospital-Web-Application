using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__IndexTests : PagesTests<IAppointmentRepo, Appointment, AppointmentData, AppointmentView> {
        [TestInitialize] public void Init() => Init(x => new Appointment(x));
        [TestMethod] public async Task LoginTest() {
            var html = await getHtmlPage("/Identity/Account/Login");
            isNotNull(html);
            isTrue(html.Contains("Use a local account to log in."));
        }
        //[TestMethod] public async Task LoginTest2() { TODO
        //    var html = await getHtmlPage("/Identity/Account/Manage", clientTest);
        //    isNotNull(html);
        //    //isTrue(html.Contains("Use a local account to log in."));
        //}
    }
}
