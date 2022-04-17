using EMEHospitalWebApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data;

[TestClass] public class UniqueDataTests : AbstractClassTests {
    private class testClass : UniqueData { }
    protected override object CreateObj() => new testClass();
    [TestMethod] public void NewIdTest() {
        IsNotNull(UniqueData.NewId);
        AreNotEqual(UniqueData.NewId, UniqueData.NewId);
        var pi = typeof(UniqueData).GetProperty(nameof(UniqueData.NewId));
        IsFalse(pi?.CanWrite);
    }
    [TestMethod] public void IdTest() => IsProperty<string>();
}
