using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class RepoTests 
        : AbstractClassTests<Repo<Appointment, AppointmentData>, PagedRepo<Appointment, AppointmentData>> {
        private class testClass : Repo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new (d);
        }
        protected override Repo<Appointment, AppointmentData> createObj() => new testClass(null, null);
    }

    [TestClass] public class PagedRepoTests
        : AbstractClassTests<PagedRepo<Appointment, AppointmentData>, OrderedRepo<Appointment, AppointmentData>> {
        private class testClass : PagedRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new(d);
        }
        protected override PagedRepo<Appointment, AppointmentData> createObj() => new testClass(null, null);
    }
    [TestClass] public class HospitalWebAppDbTests : SealedBaseTests<HospitalWebAppDb, DbContext> {
        protected override HospitalWebAppDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
