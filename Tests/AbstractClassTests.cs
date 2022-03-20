using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class AbstractClassTests : BaseTests {
    [TestMethod] public void IsAbstractTest() => IsTrue(Obj?.GetType()?.BaseType?.IsAbstract ?? false);
}