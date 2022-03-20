using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class RepoTests : AbstractClassTests {
        private class TestClass : Repo<Appointment, AppointmentData> {
            public TestClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected override Appointment ToDomain(AppointmentData d) => new (d);
        }
        protected override object CreateObj() => new TestClass(null, null);
    }
}
