using System.Linq;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class HospitalWebAppDbTests : SealedBaseTests<HospitalWebAppDb, DbContext> {
        private HospitalWebAppDb? db;
        protected override HospitalWebAppDb createObj() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            return db;
        }
        private void dbTest<TData>(DbSet<TData>? set) where TData : class, new() {
            var d = GetRandom.Value<TData>();
            set?.Add(d);
            _ = db?.SaveChanges();
            areEqual(d, db?.Find<TData>(d?.Id));
        }
        [TestMethod] public void AppointmentsTest() => dbTest(db?.Appointments);
        [TestMethod] public void PatientsTest() => dbTest(db?.Patients);
        [TestMethod] public void CountriesTest() => dbTest(db?.Countries);
        [TestMethod] public void CurrenciesTest() => dbTest(db?.Currencies);
        [TestMethod] public void CountryCurrencyTest() => dbTest(db?.CountryCurrency);
        [TestMethod] public void PatientAppointmentTest() => dbTest(db?.PatientAppointment);
        [TestMethod] public void InitializeTablesTest() {
            var b = new ModelBuilder();
            HospitalWebAppDb.InitializeTables(b);
            foreach (var e in db?.Model.GetEntityTypes()!) {
                isTrue(b.Model.GetEntityTypes().Any(x => x.GetTableName() == e.GetTableName()));
            }
        }
    }
}
