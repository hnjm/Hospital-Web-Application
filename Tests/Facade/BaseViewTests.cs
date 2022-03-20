using EMEHospitalWebApp.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class BaseViewTests : AbstractClassTests {
        private class TestClass : BaseView { }
        protected override object CreateObj() => new TestClass();
    }
}
