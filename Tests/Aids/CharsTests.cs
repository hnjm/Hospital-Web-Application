using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class CharsTests : IsTypeTested {
        [TestMethod] public void IsNameCharTest() {
            Assert.IsTrue(Chars.IsNameChar('a'));
            Assert.IsTrue(Chars.IsNameChar('9'));
            Assert.IsFalse(Chars.IsNameChar('.'));
            Assert.IsFalse(Chars.IsNameChar('_'));
            Assert.IsFalse(Chars.IsNameChar(':'));
        }
        [TestMethod] public void IsFullNameCharTest() {
            Assert.IsTrue(Chars.IsFullNameChar('a'));
            Assert.IsTrue(Chars.IsFullNameChar('9'));
            Assert.IsTrue(Chars.IsFullNameChar('.'));
            Assert.IsFalse(Chars.IsFullNameChar('_'));
            Assert.IsFalse(Chars.IsFullNameChar(':'));
        }
    }
}
