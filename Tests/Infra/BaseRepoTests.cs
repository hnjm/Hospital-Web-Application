using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    [TestClass] public class BaseRepoTests
    : AbstractClassTests<BaseRepo<Appointment, AppointmentData>, object> {
        private class testClass : BaseRepo<Appointment, AppointmentData> {
            public testClass(DbContext? c, DbSet<AppointmentData>? s) : base(c, s) { }
            public override bool Add(Appointment obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Appointment obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Appointment> Get() => throw new NotImplementedException();
            public override Appointment Get(string id) => throw new NotImplementedException();
            public override List<Appointment> GetAll(Func<Appointment, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<Appointment>> GetAsync() => throw new NotImplementedException();
            public override Task<Appointment> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(Appointment obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Appointment obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Appointment, AppointmentData> createObj() => new testClass(null, null);
        [TestMethod] public void dbTest() => isReadOnly<DbContext>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<AppointmentData>>();
        [TestMethod] public void BaseRepoTest() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            var set = db?.Appointments;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task ClearTest() {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<AppointmentData>());
            areEqual(0, await set.CountAsync());
            await db.SaveChangesAsync();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Appointment));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Appointment));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Appointment, dynamic>));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Appointment));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Appointment));
    }
}
