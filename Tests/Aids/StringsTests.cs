using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class StringsTests : TypeTests {
        private string? testStr1;
        private string? testStr2;
        private string? testStrEmpty;
        [TestInitialize] public void Init() {
            testStr1 = "a1b1c1.d1e1f1.g1h1i1";
            testStr2 = "a1b1c1";
            testStrEmpty = string.Empty;
        }
        [TestMethod] public void RemoveTest() => areEqual("abc.def.ghi", testStr1.Remove("1"));
        [TestMethod] public void IsTypeNameTest() {
            isFalse(testStr1.IsTypeName());
            var s = testStr1.Remove("1");
            isFalse(s.IsTypeName());
            s = s.RemoveTail();
            isFalse(s.IsTypeName());
            s = s.RemoveTail();
            isTrue(s.IsTypeName());
        }
        [TestMethod] public void IsTypeFullNameTest() {
            isTrue(testStr1.IsTypeFullName());
            isTrue(testStr1.Remove("1").IsTypeFullName());
        }
        [TestMethod] public void RemoveTailTest() {
            areEqual("a1b1c1.d1e1f1", testStr1.RemoveTail());
            areEqual("", testStr2.RemoveTail());
            areEqual("", testStrEmpty.RemoveTail());
        }
        [TestMethod] public void RemoveHeadTest() {
            areEqual("d1e1f1.g1h1i1", testStr1.RemoveHead());
            areEqual("", testStr2.RemoveHead());
            areEqual("", testStrEmpty.RemoveHead());
        }
    }
}
