using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class GetRandomTests : IsTypeTested
    {
        private void Test<T>(T min, T max) where T : IComparable<T>
        {
            var x = GetRandom.Value(min, max);
            var y = GetRandom.Value(min, max);
            IsInstanceOfType(x, typeof(T));
            IsInstanceOfType(y, typeof(T));
            IsTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            IsTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            AreNotEqual(x, y);
        }

        [DataRow(-1000L, 1000L)]
        [DataRow(1000L, -1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(0L, 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [TestMethod]
        public void Int64Test(long min, long max) => Test(min, max);

        [DataRow(-1000, 1000)]
        [DataRow(1000, -1000)]
        [DataRow(-1000, 0)]
        [DataRow(0, 1000)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [TestMethod]
        public void Int32Test(int min, int max) => Test(min, max);

        [DataRow(-1000.0, 1000.0)]
        [DataRow(1000.0, -1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [TestMethod]
        public void DoubleTest(double min, double max) => Test(min, max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', 'p')]
        [DataRow('A', 'z')]
        [TestMethod]
        public void CharTest(char min, char max) => Test(min, max);

        [TestMethod]
        public void BoolTest()
        {
            var x = GetRandom.Bool();
            var y = GetRandom.Bool();
            var i = 0;
            while (x == y)
            {
                y = GetRandom.Bool();
                if (i == 5) AreNotEqual(x, y);
                i++;
            }
        }

        [DynamicData(nameof(DateTimeValues))]
        [TestMethod]
        public void DateTimeTest(DateTime min, DateTime max) => Test(min, max);
        private static IEnumerable<object[]> DateTimeValues => new List<object[]> {
            new object[]{ DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100) },
            new object[]{ DateTime.Now.AddYears(100), DateTime.Now.AddYears(-100) },
            new object[]{ DateTime.MaxValue.AddYears(-100), DateTime.MaxValue },
            new object[]{ DateTime.MinValue, DateTime.MinValue.AddYears(100) },
        };

        [TestMethod] public void StringTest() {
            var x = GetRandom.Value<string>();
            var y = GetRandom.Value<string>();
            IsInstanceOfType(x, typeof(string));
            IsInstanceOfType(y, typeof(string));
            AreNotEqual(x, y);
        }

        [TestMethod] public void ValueTest() {
            var x = GetRandom.Value<AppointmentData>();
            var y = GetRandom.Value<AppointmentData>();
            AreNotEqual(x.Id, y.Id, nameof(x.Id));
            AreNotEqual(x.PatientsId, y.PatientsId, nameof(x.PatientsId));
            AreNotEqual(x.DoctorsId, y.DoctorsId, nameof(x.DoctorsId));
            AreNotEqual(x.DateTime, y.DateTime, nameof(x.DateTime));
            AreNotEqual(x.DiagnosisId, y.DiagnosisId, nameof(x.DiagnosisId));
        }
    }
}
