using System;
using System.Threading.Tasks;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class CrudRepoTests
    : AbstractClassTests<CrudRepo<Appointment, AppointmentData>, BaseRepo<Appointment, AppointmentData>> {
        private HospitalWebAppDb? db;
        private DbSet<AppointmentData>? set;
        private AppointmentData? d;
        private Appointment? a;
        private int cnt;
        private class testClass : CrudRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            protected internal override Appointment toDomain(AppointmentData d) => new(d);
        }
        protected override CrudRepo<Appointment, AppointmentData> createObj() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            set = db?.Appointments;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            initSet();
            initAdr();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<AppointmentData>());
            _ = db?.SaveChanges();
        }
        private void initAdr() {
            d = GetRandom.Value<AppointmentData>();
            isNotNull(d);
            a = new Appointment(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task AddTest() {
            isNotNull(a);
            isNotNull(set);
            _ = obj?.Add(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(a);
            isNotNull(set);
            _ = await obj.AddAsync(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            isNotNull(d);
            await GetTest();
            _ = obj.Delete(d.Id);
            var x = await obj.GetAsync(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.Id);
            var x = await obj.GetAsync(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task GetTest() {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }

        [DataRow(nameof(Appointment.Id))]
        [DataRow(nameof(Appointment.PatientsId))]
        [DataRow(nameof(Appointment.DoctorsId))]
        [DataRow(nameof(Appointment.DateTime))]
        [DataRow(nameof(Appointment.DiagnosisId))]
        [DataRow(nameof(Appointment.Patients))]
        [DataRow(nameof(Appointment.ToString))]
        [DataRow(null)]
        [TestMethod] public void GetAllTest(string s) {
            Func<Appointment, dynamic>? orderBy = s switch {
                nameof(Appointment.Id) => x => x.Id,
                nameof(Appointment.PatientsId) => x => x.PatientsId,
                nameof(Appointment.DoctorsId) => x => x.DoctorsId,
                nameof(Appointment.DateTime) => x => x.DateTime,
                nameof(Appointment.DiagnosisId) => x => x.DiagnosisId,
                nameof(Appointment.Patients) => x => x.DateTime,
                nameof(Appointment.ToString) => x => x.ToString(),
                _ => null
            };
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < cnt - 1; i++) {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<AppointmentData>() as AppointmentData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Appointment(dX);
            _ = obj.Update(aX);
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<AppointmentData>() as AppointmentData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Appointment(dX);
            _ = await obj.UpdateAsync(aX);
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(dX, x.Data);
        }
    }
}
