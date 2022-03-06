using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class MethodsTests : IsTypeTested {
        [TestMethod] public void HasAttributeTest() {
            Assert.AreEqual("test1", new List<string>() { "test1", "test2" }.GetFirst());
            Assert.AreEqual(null, new List<string>().GetFirst());
        }
    }
}
