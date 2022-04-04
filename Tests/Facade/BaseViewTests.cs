using EMEHospitalWebApp.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class BaseViewTests : AbstractClassTests {
        private class TestClass : UniqueView { }
        protected override object CreateObj() => new TestClass();
    }
}
