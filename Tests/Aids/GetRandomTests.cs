using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetRandomTests : TypeTests {
        private static void Test<T>(T min, T max) where T : IComparable<T> {
            var x = GetRandom.Value(min, max);
            var y = GetRandom.Value(min, max);
            while (x == y) {
                if (Equals(min, max)) min = GetRandom.Value(typeof(T)) ?? new Random().Next();
                y = GetRandom.Value(min, max);
            }
            isInstanceOfType(x, typeof(T));
            isInstanceOfType(y, typeof(T));
            isTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            isTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            areNotEqual(x, y);
        }

        [DataRow(-1000L, 1000L)]
        [DataRow(1000L, -1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(0L, 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [DataRow(null, null)]
        [TestMethod] public void Int64Test(long min, long max) => Test(min, max);

        [DataRow(-1000, 1000)]
        [DataRow(1000, -1000)]
        [DataRow(-1000, 0)]
        [DataRow(0, 1000)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [DataRow(1, 1)]
        [TestMethod] public void Int32Test(int min, int max) => Test(min, max);

        [DataRow(-1000.0, 1000.0)]
        [DataRow(1000.0, -1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1.1, 1.1)]
        [TestMethod] public void DoubleTest(double min, double max) => Test(min, max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', 'p')]
        [DataRow('A', 'z')]
        [TestMethod] public void CharTest(char min, char max) => Test(min, max);
        
        [TestMethod] public void BoolTest() => test(GetRandom.Bool);

        [DynamicData(nameof(DateTimeValues))]
        [TestMethod] public void DateTimeTest(DateTime min, DateTime max) => Test(min, max);
        private static IEnumerable<object[]> DateTimeValues => new List<object[]> {
            new object[]{ DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100) },
            new object[]{ DateTime.Now.AddYears(100), DateTime.Now.AddYears(-100) },
            new object[]{ DateTime.MaxValue.AddYears(-100), DateTime.MaxValue },
            new object[]{ DateTime.MinValue, DateTime.MinValue.AddYears(100) },
        };

        [TestMethod] public void StringTest() {
            var x = GetRandom.Value<string>();
            var y = GetRandom.Value<string>();
            isInstanceOfType(x, typeof(string));
            isInstanceOfType(y, typeof(string));
            areNotEqual(x, y);
        }

        [TestMethod] public void ValueTest() {
            var x = GetRandom.Value<AppointmentData>();
            var y = GetRandom.Value<AppointmentData>();
            isNotNull(x);
            isNotNull(y);
            areNotEqual(x?.Id, y?.Id, nameof(x.Id));
            areNotEqual(x?.PatientsId, y?.PatientsId, nameof(x.PatientsId));
            areNotEqual(x?.DoctorsId, y?.DoctorsId, nameof(x.DoctorsId));
            areNotEqual(x?.DateTime, y?.DateTime, nameof(x.DateTime));
            areNotEqual(x?.DiagnosisId, y?.DiagnosisId, nameof(x.DiagnosisId));
            y = GetRandom.Value(typeof(Array));
            isNull(y);
            y = GetRandom.Value(typeof(bool));
            isTrue(y?.GetType() == typeof(bool));
            y = GetRandom.Value<bool>();
            isTrue(y?.GetType() == typeof(bool));
            y = GetRandom.Value(typeof(char));
            isTrue(y?.GetType() == typeof(char));
            y = GetRandom.Value<StringBuilder>();
            isTrue(y?.GetType() == typeof(StringBuilder));
        }

        [TestMethod] public void EnumOfGenericTest() => test(() => GetRandom.EnumOf<IsoGender>());

        [DataRow(typeof(IsoGender))] 
        [TestMethod] public void EnumOfTest(Type t) => test(() => GetRandom.EnumOf(t));

        private static void test<T>(Func<T> f, int count = 5) {
            var x = f();
            var y = f();
            var i = 0;
            while (x != null && x.Equals(y)) {
                y = f();
                if (i == count) areNotEqual(x, y);
                i++;
            }
        }

        [DataRow(typeof(bool?), false)]
        [DataRow(typeof(int), false)]
        [DataRow(typeof(decimal?), false)]
        [DataRow(typeof(string), false)]
        [DataRow(typeof(IsoGender?), false)]
        [DataRow(typeof(IsoGender), true)]
        [DataRow(typeof(DateTime), false)]
        [TestMethod] public void IsEnumTest(Type t, bool expected)
            => areEqual(expected, GetRandom.isEnum(t));

        [DataRow(typeof(bool?), typeof(bool))]
        [DataRow(typeof(int?), typeof(int))]
        [DataRow(typeof(decimal?), typeof(decimal))]
        [DataRow(typeof(string), typeof(string))]
        [DataRow(typeof(IsoGender), typeof(IsoGender))]
        [DataRow(typeof(DateTime), typeof(DateTime))]
        [TestMethod] public void GetUnderlyingTypeTest(Type nullable, Type expected) 
            => areEqual(expected, GetRandom.getUnderlyingType(nullable));
    }
}
