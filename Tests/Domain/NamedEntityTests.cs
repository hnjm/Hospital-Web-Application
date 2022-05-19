using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain {
    [TestClass] public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, UniqueEntity<CountryData>> {
        private class testClass : NamedEntity<CountryData> { }
        protected override NamedEntity<CountryData> createObj() => new testClass();
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
        [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data.Description);
    }
}
