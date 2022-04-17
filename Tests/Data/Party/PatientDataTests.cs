using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Tests.Data.Party
{
    [TestClass] public class PatientDataTests : SealedClassTests<PatientData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<IsoGender?>();
        [TestMethod] public void BirthDateTest() => IsProperty<DateTime?>();
        [TestMethod] public void IdCodeTest() => IsProperty<string?>();
        [TestMethod] public void CountryIdTest() => IsProperty<string?>();
    }
}
