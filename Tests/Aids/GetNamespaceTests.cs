using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            Assert.AreEqual("EMEHospitalWebApp.Tests.Aids", GetNamespace.OfType(this));
        }
    }
}
