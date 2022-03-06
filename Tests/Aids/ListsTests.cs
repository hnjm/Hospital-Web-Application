using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class ListsTests : IsTypeTested {
        [TestMethod] public void GetFirstTest() {
            Assert.AreEqual("test1", new List<string>() { "test1", "test2" }.GetFirst());
            Assert.AreEqual(null, new List<string>().GetFirst());
        }
        [TestMethod] public void RemoveTest() {
            Assert.AreEqual(true, new List<string>() { "test" }.Remove("test"));
            Assert.AreEqual(false, new List<string>() { "test" }.Remove("tes"));
        }
        [TestMethod] public void IsEmptyTest() {
            Assert.AreEqual(false, new List<string>() { "test" }.IsEmpty());
            Assert.AreEqual(true, new List<string>().IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            Assert.AreEqual(true, new List<string>() { "test1", "test2" }.ContainsItem(x => x == "test2"));
            Assert.AreEqual(false, new List<string>() { "test1", "test3" }.ContainsItem(x => x == "test2"));
        }
    }
}
