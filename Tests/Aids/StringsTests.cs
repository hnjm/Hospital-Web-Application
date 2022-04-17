using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class StringsTests : IsTypeTested {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "a1b1c1.d1e1f1.g1h1i1";
        [TestMethod] public void RemoveTest() => AreEqual("abc.def.ghi", testStr.Remove("1"));
        [TestMethod] public void IsTypeNameTest() {
            IsFalse(testStr.IsTypeName());
            var s = testStr.Remove("1");
            IsFalse(s.IsTypeName());
            s = s.RemoveTail();
            IsFalse(s.IsTypeName());
            s = s.RemoveTail();
            IsTrue(s.IsTypeName());
        }
        [TestMethod] public void IsTypeFullNameTest() {
            IsFalse(testStr.IsTypeFullName());
            IsTrue(testStr.Remove("1").IsTypeFullName());
        }
        [TestMethod] public void RemoveTailTest() => AreEqual("a1b1c1.d1e1f1", testStr.RemoveTail());
    }
}
