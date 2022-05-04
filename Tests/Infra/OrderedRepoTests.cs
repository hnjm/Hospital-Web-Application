using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class OrderedRepoTests
    : AbstractClassTests<OrderedRepo<Appointment, AppointmentData>, FilteredRepo<Appointment, AppointmentData>> {
        private class testClass : OrderedRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new(d);
        }
        protected override OrderedRepo<Appointment, AppointmentData> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            var set = db?.Appointments;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => isProperty<string?>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);

        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Appointment.Id), true)]
        [DataRow(nameof(Appointment.Id), false)]
        [DataRow(nameof(Appointment.PatientsId), true)]
        [DataRow(nameof(Appointment.PatientsId), false)]
        [DataRow(nameof(Appointment.DoctorsId), true)]
        [DataRow(nameof(Appointment.DoctorsId), false)]
        [DataRow(nameof(Appointment.DateTime), true)]
        [DataRow(nameof(Appointment.DateTime), false)]
        [TestMethod] public void CreateSqlTest(string s, bool isDescending) { 
            obj.CurrentOrder = (s is null) ? s: isDescending ? s + testClass.DescendingString: s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }

        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            var sDes = s + testClass.DescendingString;
            obj.CurrentOrder = isDescending ? c + sDes : c;
            var actual = obj.SortOrder(s);
            var expected = isSame ? (isDescending ? s : sDes) : sDes;
            areEqual(expected, actual);
        }
    }
}
