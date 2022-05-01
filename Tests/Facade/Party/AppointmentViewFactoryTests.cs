using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewFactoryTests : SealedClassTests<AppointmentViewFactory, BaseViewFactory<AppointmentView, Appointment, AppointmentData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<AppointmentData>();
            var e = new Appointment(d);
            var v = new AppointmentViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.PatientsId, e.PatientsId);
            areEqual(v.DoctorsId, e.DoctorsId);
            areEqual(v.DateTime, e.DateTime); 
            areEqual(v.DiagnosisId, e.DiagnosisId);
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<AppointmentView>() as AppointmentView;
            var e = new AppointmentViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areEqual(e.Id, v.Id);
            areEqual(e.PatientsId, v.PatientsId);
            areEqual(e.DoctorsId, v.DoctorsId);
            areEqual(e.DateTime, v.DateTime);
            areEqual(e.DiagnosisId, v.DiagnosisId);
        }
    }
}
