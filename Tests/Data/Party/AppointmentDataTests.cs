using System;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party
{
    [TestClass]
    public class AppointmentDataTests: BaseTests<AppointmentData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void PatientsIdTest() => IsProperty<string?>();
        [TestMethod] public void DoctorsIdTest() => IsProperty<string?>();
        [TestMethod] public void DateTimeTest() => IsProperty<DateTime?>();
        [TestMethod] public void DiagnosisIdTest() => IsProperty<string?>();
    }
}
