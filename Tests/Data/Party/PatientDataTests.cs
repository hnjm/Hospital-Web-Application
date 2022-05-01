using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Tests.Data.Party
{
    [TestClass] public class PatientDataTests : SealedClassTests<PatientData, UniqueData>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void BirthDateTest() => isProperty<DateTime?>();
        [TestMethod] public void IdCodeTest() => isProperty<string?>();
        [TestMethod] public void CountryIdTest() => isProperty<string?>();
    }
}
