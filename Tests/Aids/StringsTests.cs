using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class StringsTests : IsTypeTested {
        [TestMethod] public void RemoveTest() {
            Assert.AreEqual("test", Strings.Remove("test2", "2"));
        }
        [TestMethod] public void IsRealTypeNameTest() {
            Assert.AreEqual(true, Strings.IsTypeName("test"));
        }
        [TestMethod] public void RemoveTailTest() {
            Assert.AreEqual("test", Strings.RemoveTail("test.remove"));
        }
    }
}
