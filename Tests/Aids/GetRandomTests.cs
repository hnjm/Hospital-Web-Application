using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetRandomTests : IsTypeTested {
        [TestMethod] public void Int32Test() {
            var expected = 0.GetType();
            Assert.AreEqual(expected, GetRandom.Int32().GetType());
        }
        [TestMethod] public void DoubleTest() {
            var expected = 0.2.GetType();
            Assert.AreEqual(expected, GetRandom.Double().GetType());
        }
        [TestMethod] public void CharTest() {
            var expected = 'f'.GetType();
            Assert.AreEqual(expected, GetRandom.Char().GetType());
        }
        [TestMethod] public void BoolTest() {
            var expected = false.GetType();
            Assert.AreEqual(expected, GetRandom.Bool().GetType());
        }
        [TestMethod] public void DateTimeTest() {
            var expected = DateTime.Now.GetType();
            Assert.AreEqual(expected, GetRandom.DateTime().GetType());
        }
        [TestMethod] public void StringTest() {
            var expected = "test".GetType();
            Assert.AreEqual(expected, GetRandom.String().GetType());
        }
        [TestMethod] public void ValueTest() {
            var expected = "test".GetType();
            Assert.AreEqual(expected, GetRandom.Value<string>().GetType());
        }
    }
}
