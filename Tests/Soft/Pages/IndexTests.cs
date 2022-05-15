using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class IndexTests : PagesTests<IAppointmentRepo, Appointment, AppointmentData, AppointmentView> {
        [TestInitialize] public void Init() => Init(x => new Appointment(x));
    }
}
