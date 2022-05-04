using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class FilteredRepoTests
        : AbstractClassTests<FilteredRepo<Appointment, AppointmentData>, CrudRepo<Appointment, AppointmentData>> {
        private class testClass : FilteredRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new(d);
        }
        protected override FilteredRepo<Appointment, AppointmentData> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            var set = db?.Appointments;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();

        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void CreateSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}
