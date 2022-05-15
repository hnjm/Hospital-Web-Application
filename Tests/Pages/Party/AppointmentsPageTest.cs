using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages.Party {
    [TestClass] public class AppointmentsPageTests 
        : SealedBaseTests<AppointmentsPage, PagedPage<AppointmentView, Appointment, IAppointmentRepo>> {
        protected override AppointmentsPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new AppointmentsPage(new AppointmentsRepo(db));
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
    }
}
