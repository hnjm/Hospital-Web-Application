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
        [TestMethod] public void GetAttributeTest() {
            var m = GetType().GetMethod(nameof(GetAttributeTest));
            isNotNull(m.GetAttribute<TestMethodAttribute>());
            isNull(m.GetAttribute<TestInitializeAttribute>());
        }
    }
}
