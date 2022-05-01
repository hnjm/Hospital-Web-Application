using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain;

[TestClass] public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity> {
    private CountryData? d;
    private class testClass : UniqueEntity<CountryData> {
        public testClass() : this(new CountryData()) { }
        public testClass(CountryData d) : base(d) { }
    }
    protected override UniqueEntity<CountryData> createObj() {
        d = GetRandom.Value<CountryData>();
        return new testClass(d);
    } 
    [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
    [TestMethod] public void DataTest() => isReadOnly(d);
    [TestMethod] public void DefaultSrtTest() => areEqual("Undefined", UniqueEntity.DefaultSrt);
}
