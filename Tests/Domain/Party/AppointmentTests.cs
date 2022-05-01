using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party {
    [TestClass] public class AppointmentTests : SealedClassTests<Appointment, UniqueEntity<AppointmentData>> {
        protected override Appointment createObj() => new Appointment(GetRandom.Value<AppointmentData>());
        [TestMethod] public void PatientsIdTest() => isReadOnly(obj.Data.PatientsId);
        [TestMethod] public void DoctorsIdTest() => isReadOnly(obj.Data.DoctorsId);
        [TestMethod] public void DateTimeTest() => isReadOnly(obj.Data.DateTime);
        [TestMethod] public void DiagnosisIdTest() => isReadOnly(obj.Data.DiagnosisId);
        [TestMethod] public void ToStringTest() => isInconclusive();
    }
}
