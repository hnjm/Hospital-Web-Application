using System.Reflection;
using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetAssemblyTests : IsTypeTested {
        [TestMethod] public void ByNameTest() {
            var expected = 0.GetType();
            Assert.AreEqual(null, GetAssembly.ByName("test"));
        }
        [TestMethod] public void OfTypeTest() {
            var expected = 0.GetType();
            Assert.IsNotNull(GetAssembly.OfType("test"));
        }
        [TestMethod] public void TypesTest() {
            Assert.IsNotNull(GetAssembly.Types(GetAssembly.OfType("test")));
        }
        [TestMethod] public void TypeTest() {
            Assert.IsNotNull(GetAssembly.Types(GetAssembly.OfType("test")));
        }
    }
}
