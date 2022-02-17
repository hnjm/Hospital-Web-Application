using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EMEHospitalWebApp.Tests.Data.Party
{
    [TestClass]
    public class PatientDataTests : BaseTests<PatientData>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<string?>();
        [TestMethod] public void BirthDateTest() => isProperty<DateTime?>();
        [TestMethod] public void IdCodeTest() => isProperty<string?>();
    }
}
