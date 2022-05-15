using EMEHospitalWebApp.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        private class TestClass : UniqueView { }
        protected override UniqueView createObj() => new TestClass();
        [TestMethod] public void IdTest() {
            isProperty<string>();
            isRequired<string>();
        }
        [TestMethod] public void TokenTest() {
            isProperty<byte[]>();
            isRequired<byte[]>();
        }
    }
}
