using EMEHospitalWebApp.Aids;
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
        
        [TestMethod] public void CreateTest() {}
        [TestMethod] public void CreateViewTest() {
            var v = GetRandom.Value<AppointmentView>();
            var d = obj.Create(v);
            arePropertiesEqual(v, d.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<AppointmentData>();
            var v = obj.Create(new Appointment(d));
            arePropertiesEqual(d, v);
        }
    }
}
