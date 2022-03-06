using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        [TestMethod] public void BelongsToTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.BelongsTo(s, "test"));
        }
        [TestMethod] public void NameIsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.NameIs(s, "test"));
        }
        [TestMethod] public void NameEndsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.NameEnds(s, "test"));
        }
        [TestMethod] public void NameStartsTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.NameStarts(s, "test"));
        }
        [TestMethod] public void IsRealTypeTest() {
            var s = "test".GetType();
            Assert.AreEqual(true, Types.IsRealType(s));
        }
        [TestMethod] public void GetNameTest() {
            var s = "test".GetType();
            Assert.AreEqual("String", Types.GetName(s));
        }
        [TestMethod] public void DeclaredMembersTest() {
            var s = "test".GetType();
            Assert.IsTrue(Types.DeclaredMembers(s).Count != 0);
        }
        [TestMethod] public void IsInheritedTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.IsInherited(s, s));
        }
        [TestMethod] public void HasAttributeTest() {
            var s = "test".GetType();
            Assert.AreEqual(false, Types.HasAttribute<TestClassAttribute>(s));
        }
        [TestMethod] public void MethodTest() {
            var s = "test".GetType();
            Assert.AreEqual(null, Types.Method(s, "test"));
        }
    }
}
