using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party;

[TestClass] public class PatientAppointmentTests : SealedClassTests<PatientAppointment, NamedEntity<PatientAppointmentData>> {
    [TestMethod] public void PatientIdTest() => isReadOnly(obj.Data.PatientId);
    [TestMethod] public void AppointmentIdTest() => isReadOnly(obj.Data.AppointmentId);
    [TestMethod] public void PatientTest() => itemTest<IPatientRepo, Patient, PatientData>(
        obj.PatientId, d => new Patient(d), () => obj.Patient);
    [TestMethod] public void AppointmentTest() => itemTest<IAppointmentRepo, Appointment, AppointmentData>(
        obj.AppointmentId, d => new Appointment(d), () => obj.Appointment);
}
