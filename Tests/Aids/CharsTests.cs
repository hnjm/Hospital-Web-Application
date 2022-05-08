using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class CharsTests : TypeTests {
        private char letter;
        private char digit;
        [TestInitialize] public void Init() {
            letter = GetRandom.Char('a', 'z');
            digit = GetRandom.Char('0', '9');
        }
        [TestMethod] public void IsNameCharTest() {
            Assert.IsTrue(letter.IsNameChar());
            Assert.IsTrue(digit.IsNameChar());
            Assert.IsTrue('`'.IsNameChar());
            Assert.IsFalse('_'.IsNameChar());
            Assert.IsFalse('.'.IsNameChar());
            Assert.IsFalse(':'.IsNameChar());
        }
        [TestMethod] public void IsFullNameCharTest() {
            Assert.IsTrue(letter.IsFullNameChar());
            Assert.IsTrue(digit.IsFullNameChar());
            Assert.IsTrue('.'.IsFullNameChar());
            Assert.IsTrue('`'.IsFullNameChar());
            Assert.IsTrue('_'.IsFullNameChar());
            Assert.IsFalse(':'.IsFullNameChar());
            Assert.IsFalse(';'.IsFullNameChar());
        }
    }
}
