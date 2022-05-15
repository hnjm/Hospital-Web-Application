using System.Collections.Generic;
using System.Linq;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<AppointmentData>, object> {
        private class testClass : BaseInitializer<AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected override IEnumerable<AppointmentData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<AppointmentData> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            var set = db?.Appointments;
            return new testClass(db, set);
        }
        [TestMethod] public void InitTest() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            isFalse(db?.Appointments?.Any());
            new AppointmentsInitializer(db).Init();
            isTrue(db?.Appointments?.Any());
        }
    }
}
