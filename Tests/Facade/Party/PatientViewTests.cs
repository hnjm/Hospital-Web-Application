using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Tests.Facade.Party
{
    [TestClass] public class PatientViewTests : SealedClassTests<PatientView, UniqueView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void BirthDateTest() => isProperty<DateTime?>();
        [TestMethod] public void IdCodeTest() => isProperty<string?>();
        [TestMethod] public void CountryIdTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string>();
        
    }
}
