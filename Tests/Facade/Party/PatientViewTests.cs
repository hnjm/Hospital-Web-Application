using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EMEHospitalWebApp.Tests.Facade.Party
{
    [TestClass]
    public class PatientViewTests : BaseTests<PatientView>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<string?>();
        [TestMethod] public void BirthDateTest() => IsProperty<DateTime?>();
        [TestMethod] public void IdCodeTest() => IsProperty<string?>();
        [TestMethod] public void FullNameTest() => IsProperty<string>();
        
    }
}
