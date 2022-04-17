using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewFactoryTests : SealedClassTests<AppointmentViewFactory> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<AppointmentData>();
            var e = new Appointment(d);
            var v = new AppointmentViewFactory().Create(e);
            IsNotNull(v);
            AreEqual(v.Id, e.Id);
            AreEqual(v.PatientsId, e.PatientsId);
            AreEqual(v.DoctorsId, e.DoctorsId);
            AreEqual(v.DateTime, e.DateTime); 
            AreEqual(v.DiagnosisId, e.DiagnosisId);
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<AppointmentView>() as AppointmentView;
            var e = new AppointmentViewFactory().Create(v);
            IsNotNull(e);
            IsNotNull(v);
            ArePropertiesEqual(e, v);
            AreEqual(e.Id, v.Id);
            AreEqual(e.PatientsId, v.PatientsId);
            AreEqual(e.DoctorsId, v.DoctorsId);
            AreEqual(e.DateTime, v.DateTime);
            AreEqual(e.DiagnosisId, v.DiagnosisId);
        }
    }
}
