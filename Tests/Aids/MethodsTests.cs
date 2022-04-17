using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class MethodsTests : IsTypeTested {
        [TestMethod] public void HasAttributeTest() {
            var m = GetType().GetMethod(nameof(HasAttributeTest));
            IsTrue(m.HasAttribute<TestMethodAttribute>());
            IsFalse(m.HasAttribute<TestInitializeAttribute>());
        }
    }
}
