using System;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewTests : SealedClassTests<AppointmentView, UniqueView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void PatientsIdTest() => isProperty<string?>();
        [TestMethod] public void DoctorsIdTest() => isProperty<string?>();
        [TestMethod] public void DateTimeTest() => isProperty<DateTime?>();
        [TestMethod] public void DiagnosisIdTest() => isProperty<string?>();
    }
}
