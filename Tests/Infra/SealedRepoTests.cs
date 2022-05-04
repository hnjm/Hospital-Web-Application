using System;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra {
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData>
    : SealedBaseTests<TClass, TBaseClass>
    where TClass : FilteredRepo<TDomain, TData>
    where TBaseClass : class
    where TDomain : UniqueEntity<TData>, new()
    where TData : UniqueData, new() {
        private static Type universityType => typeof(HospitalWebAppDb);
        private static Type setType => typeof(DbSet<TData>);
        private HospitalWebAppDb universityDb {
            get {
                var o = obj.db;
                isNotNull(o);
                var db = o as HospitalWebAppDb;
                isNotNull(db);
                return db;
            }
        }
        protected void instanceTest(object? o, Type t) {
            isNotNull(o);
            isInstanceOfType(o, t);
        }
        protected void instanceTest(object? o, Type t, object? expected) {
            instanceTest(o, t);
            instanceTest(expected, t);
            areEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj.db, universityType);
        [TestMethod] public void DbSetTest() => instanceTest(obj.set, setType, getSet(universityDb));
        [TestMethod] public void ToDomainTest() {
            var d = GetRandom.Value<TData>();
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            arePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void AddFilterTest() {
            string contains(string s) => $"x.{s}.Contains";
            string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.createSql();
            var s = q.Expression.ToString();
            foreach (var p in typeof(TData).GetProperties()) {
                if (p.Name == nameof(UniqueData.Token)) continue;
                isTrue(
                    p.PropertyType == typeof(string) ? s.Contains(contains(p.Name)) : s.Contains(toStrContains(p.Name)),
                    $"No Where part found for the property {p.Name}");
            }
        }
        protected abstract object? getSet(HospitalWebAppDb db);
    }
}
