using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class ListsTests : TypeTests {
        private List<int> list = new ();
        [TestInitialize] public void Init() => list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        [TestMethod] public void GetFirstTest() => areEqual(1, list.GetFirst());
        [TestMethod] public void RemoveTest() {
            var cnt = list.Remove(x => x < 4);
            areEqual(3, cnt);
            areEqual(4, list.GetFirst());
        }
        [TestMethod] public void IsEmptyTest() {
            List<CountryData>? countries = null;
            isFalse(list.IsEmpty());
            isTrue(countries.IsEmpty());
            isTrue(new List<string>().IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            isTrue(list.ContainsItem(x => x < 2));
            isFalse(list.ContainsItem(x => x > 6));
        }
    }
}
