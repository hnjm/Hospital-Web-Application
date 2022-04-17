using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class ListsTests : IsTypeTested {
        private List<int> list = new ();
        [TestInitialize] public void Init() => list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        [TestMethod] public void GetFirstTest() => AreEqual(1, list.GetFirst());
        [TestMethod] public void RemoveTest() {
            var cnt = list.Remove(x => x < 4);
            AreEqual(3, cnt);
            AreEqual(4, list.GetFirst());
        }
        [TestMethod] public void IsEmptyTest() {
            List<CountryData>? countries = null;
            IsFalse(list.IsEmpty());
            IsTrue(countries.IsEmpty());
            IsTrue(new List<string>().IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            IsTrue(list.ContainsItem(x => x < 2));
            IsFalse(list.ContainsItem(x => x > 6));
        }
    }
}
