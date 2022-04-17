using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            var obj = new CurrencyData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            AreEqual(name, n);
        }
        [TestMethod] public void OfTypeNullTest() {
            CurrencyData? obj = null;
            var n = GetNamespace.OfType(obj);
            AreEqual(string.Empty, n);
        }
    }
}
