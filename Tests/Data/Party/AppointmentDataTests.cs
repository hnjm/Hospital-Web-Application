using System;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party
{
    [TestClass]
    public class AppointmentDataTests: BaseTests<AppointmentData>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void PatientsIdTest() => isProperty<string?>();
        [TestMethod] public void DoctorsIdTest() => isProperty<string?>();
        [TestMethod] public void DateTimeTest() => isProperty<DateTime?>();
        [TestMethod] public void DiagnosisIdTest() => isProperty<string?>();
    }
}
