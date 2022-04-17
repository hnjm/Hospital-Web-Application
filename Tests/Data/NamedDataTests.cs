using EMEHospitalWebApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data;

[TestClass] public class NamedDataTests : AbstractClassTests {
    private class testClass : NamedData { }
    protected override object CreateObj() => new testClass();
    [TestMethod] public void CodeTest() => IsProperty<string>();
    [TestMethod] public void NameTest() => IsProperty<string?>();
    [TestMethod] public void DescriptionTest() => IsProperty<string?>();
}
