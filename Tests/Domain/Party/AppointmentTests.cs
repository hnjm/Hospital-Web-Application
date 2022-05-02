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
        [TestMethod] public void ToStringTest() {
            var expected = $"{obj.PatientsId} {obj.DoctorsId} {obj.DateTime} {obj.DiagnosisId}";
            areEqual(expected, obj.ToString());
        }
        [TestMethod] public void PatientAppointmentsTest()
            => itemsTest<IPatientAppointmentRepo, PatientAppointment, PatientAppointmentData>(
                d => d.PatientId = obj.Id, d => new PatientAppointment(d), () => obj.PatientAppointments);
        [TestMethod] public void PatientsTest() => relatedItemsTest<IPatientRepo, PatientAppointment, Patient, PatientData>
        (PatientAppointmentsTest, () => obj.PatientAppointments, () => obj.Patients,
            x => x.PatientId, d => new Patient(d), c => c?.Data, x => x?.Patient?.Data);
    }
}
