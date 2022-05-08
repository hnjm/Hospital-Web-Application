using System;
using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class ConcurrencyTokenTests : TypeTests {
        [TestMethod] public void ToStrTest() {
            var r = new Random();
            var b = new byte[10];
            r.NextBytes(b);
            var expected = string.Empty;
            foreach (var nr in b) expected += nr.ToString();
            var actual = ConcurrencyToken.ToStr(b);
            areEqual(expected, actual);
            actual = ConcurrencyToken.ToStr();
            areEqual(string.Empty, actual);
        }
        [TestMethod] public void ToByteArrayTest() {
            var nr = GetRandom.Int32(1, 255);
            var s = nr.ToString();
            var expected = new byte[s.Length];
            for (var i = 0; i < s.Length; i++) expected[i] = Convert.ToByte(s[i]);
            var actual = ConcurrencyToken.ToByteArray(nr.ToString());
            for (var i = 0; i < actual.Length; i++) areEqual(expected[i], actual[i]);
            actual = ConcurrencyToken.ToByteArray();
            isNotNull(actual);
        }
    }
}
