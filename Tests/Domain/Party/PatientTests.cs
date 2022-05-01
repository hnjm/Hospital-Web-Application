using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain.Party;

[TestClass] public class PatientTests : SealedClassTests<Patient, UniqueEntity<PatientData>> {
    protected override Patient createObj() => new Patient(GetRandom.Value<PatientData>());
    [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
    [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
    [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
    [TestMethod] public void BirthDateTest() => isReadOnly(obj.Data.BirthDate);
    [TestMethod] public void IdCodeTest() => isReadOnly(obj.Data.IdCode);
    [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
    [TestMethod] public void ToStringTest() => isInconclusive();
    [TestMethod] public void CountryTest() => itemTest<ICountriesRepo, Country, CountryData>(
        obj.CountryId, d => new Country(d), () => obj.Country);
}
