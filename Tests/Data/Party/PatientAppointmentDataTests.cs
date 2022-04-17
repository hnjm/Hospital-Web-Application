using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party;

[TestClass] public class PatientAppointmentDataTests : SealedClassTests<PatientAppointmentData> {
    [TestMethod] public void PatientIdTest() => IsProperty<string>();
    [TestMethod] public void AppointmentIdTest() => IsProperty<string>();
}
