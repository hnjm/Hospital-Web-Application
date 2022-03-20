using System;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewTests : SealedClassTests<AppointmentView> {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void PatientsIdTest() => IsProperty<string?>();
        [TestMethod] public void DoctorsIdTest() => IsProperty<string?>();
        [TestMethod] public void DateTimeTest() => IsProperty<DateTime?>();
        [TestMethod] public void DiagnosisIdTest() => IsProperty<string?>();
    }
}
