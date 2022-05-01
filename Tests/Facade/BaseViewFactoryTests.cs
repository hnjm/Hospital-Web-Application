using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<AppointmentView, Appointment, AppointmentData>, object> {
        private class TestClass : BaseViewFactory<AppointmentView, Appointment, AppointmentData> {
            protected override Appointment toEntity(AppointmentData d) => new(d);
        }
        protected override BaseViewFactory<AppointmentView, Appointment, AppointmentData> createObj() => new TestClass();
    }
}
