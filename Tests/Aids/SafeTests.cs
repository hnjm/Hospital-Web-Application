using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class SafeTests : IsTypeTested {
        [TestMethod] public void RunTest() {
            var list1 = new List<string>() { "test" };
            var list2 = new List<string>();
            Assert.AreEqual(true, Safe.Run(() => list1.Count == 1, true));
            Assert.AreEqual(false, Safe.Run(() => list1.Count == 2, true));
            Assert.AreEqual(false, Safe.Run(() => list2.First() == "test"));
        }
    }
}
