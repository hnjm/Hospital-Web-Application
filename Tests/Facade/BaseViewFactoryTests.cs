using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests {
        private class TestClass : BaseViewFactory<AppointmentView, Appointment, AppointmentData> {
            protected override Appointment ToEntity(AppointmentData d) => new Appointment(d);
        }
        protected override object CreateObj() => new TestClass();
    }
}
