using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class PatientViewTests : SealedClassTests<PatientView, UniqueView> {
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string?>("First name");
        [TestMethod] public void LastNameTest() => isRequired<string?>("Last name");
        [TestMethod] public void GenderTest() => isDisplayNamed<IsoGender?>("Gender");
        [TestMethod] public void BirthDateTest() => isDisplayNamed<DateTime?>("Birth Date");
        [TestMethod] public void IdCodeTest() => isDisplayNamed<string?>("ID code");
        [TestMethod] public void CountryIdTest() => isDisplayNamed<string?>("Country Id");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string>("Full name");
    }
}
