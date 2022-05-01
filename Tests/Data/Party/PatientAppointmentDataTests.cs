using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party;

[TestClass] public class PatientAppointmentDataTests : SealedClassTests<PatientAppointmentData, NamedData> {
    [TestMethod] public void PatientIdTest() => isProperty<string>();
    [TestMethod] public void AppointmentIdTest() => isProperty<string>();
}
