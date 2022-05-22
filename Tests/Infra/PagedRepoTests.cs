using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Appointment, AppointmentData>, OrderedRepo<Appointment, AppointmentData>> {
        private class testClass : PagedRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new(d);
        }
        private HospitalWebAppDb? db;
        private DbSet<AppointmentData>? set;
        private AppointmentsRepo? r;
        protected override PagedRepo<Appointment, AppointmentData> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            _ = new AppointmentsRepo(db);
            return new testClass(db, db.Appointments);
        }
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            set = db?.Appointments;
            r = new AppointmentsRepo(db);
        }
        [TestMethod] public void PageIndexTest() => isProperty<int>();
        [TestMethod] public void PageSizeTest() => isProperty<int>();
        private int addData() {
            var nr = GetRandom.Int32(2, 10);
            for (var i = 0; i < nr; i++) {
                set?.Add(GetRandom.Value<AppointmentData>());
                db?.SaveChanges();
            }
            return nr;
        }
        [TestMethod] public void TotalPagesTest() {
            var nr = addData();
            isNotNull(r);
            r.PageSize = nr;
            areEqual(1, r.TotalPages);
            r.PageSize = 1;
            areEqual(nr, r.TotalPages);
        }
        [TestMethod] public void HasNextPageTest() {
            var nr = addData();
            isNotNull(r);
            r.PageSize = 1;
            r.PageIndex = nr;
            areEqual(false, r.HasNextPage);
            r.PageIndex = 0;
            areEqual(true, r.HasNextPage);
        }
        [TestMethod] public void HasPreviousPageTest() {
            _ = addData();
            isNotNull(r);
            r.PageSize = 1;
            r.PageIndex = 0;
            areEqual(false, r.HasPreviousPage);
            r.PageIndex = 1;
            areEqual(true, r.HasPreviousPage);
        }
    }
}
