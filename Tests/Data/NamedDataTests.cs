using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data;

[TestClass] public class NamedDataTests : AbstractClassTests<NamedData, UniqueData> {
    private class testClass : NamedData { }
    protected override NamedData createObj() => new testClass();
    [TestMethod] public void CodeTest() => isProperty<string>();
    [TestMethod] public void NameTest() => isProperty<string?>();
    [TestMethod] public void DescriptionTest() => isProperty<string?>();
}
