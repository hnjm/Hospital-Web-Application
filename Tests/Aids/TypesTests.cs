using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        [TestMethod] public void BelongsToTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.BelongsTo("test"));
        }
        [TestMethod] public void NameIsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.NameIs("test"));
        }
        [TestMethod] public void NameEndsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.NameEnds("test"));
        }
        [TestMethod] public void NameStartsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.NameStarts("test"));
        }
        [TestMethod] public void IsRealTypeTest() {
            var s = "test".GetType();
            Assert.AreEqual(true, s.IsRealType());
        }
        [TestMethod] public void GetNameTest() {
            var s = "test".GetType();
            Assert.AreEqual("String", Types.GetName(s));
        }
        [TestMethod] public void DeclaredMembersTest() {
            var s = "test".GetType();
            Assert.IsTrue(s.DeclaredMembers()!.Count != 0);
        }
        [TestMethod] public void IsInheritedTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.IsInherited(s));
        }
        [TestMethod] public void HasAttributeTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, s.HasAttribute<TestClassAttribute>());
        }
        [TestMethod] public void MethodTest() {
            var s = "test".GetType();
            Assert.AreEqual(null, s.Method("test"));
        }
    }
}
