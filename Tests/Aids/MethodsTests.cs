using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class MethodsTests : TypeTests {
        [TestMethod] public void HasAttributeTest() {
            var m = GetType().GetMethod(nameof(HasAttributeTest));
            isTrue(m.HasAttribute<TestMethodAttribute>());
            isFalse(m.HasAttribute<TestInitializeAttribute>());
        }
    }
}
