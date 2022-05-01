using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class StringsTests : TypeTests {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "a1b1c1.d1e1f1.g1h1i1";
        [TestMethod] public void RemoveTest() => areEqual("abc.def.ghi", testStr.Remove("1"));
        [TestMethod] public void IsTypeNameTest() {
            isFalse(testStr.IsTypeName());
            var s = testStr.Remove("1");
            isFalse(s.IsTypeName());
            s = s.RemoveTail();
            isFalse(s.IsTypeName());
            s = s.RemoveTail();
            isTrue(s.IsTypeName());
        }
        [TestMethod] public void IsTypeFullNameTest() {
            isTrue(testStr.IsTypeFullName());
            isTrue(testStr.Remove("1").IsTypeFullName());
        }
        [TestMethod] public void RemoveTailTest() => areEqual("a1b1c1.d1e1f1", testStr.RemoveTail());
        [TestMethod] public void RemoveHeadTest() => areEqual("d1e1f1.g1h1i1", testStr.RemoveHead());
    }
}
