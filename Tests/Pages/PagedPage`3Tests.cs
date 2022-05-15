using System.ComponentModel;
using System.Linq;
using System.Reflection;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages {
    [TestClass] public class PagedPageTests
        : AbstractClassTests<PagedPage<AppointmentView, Appointment, AppointmentsRepo>,
            OrderedPage<AppointmentView, Appointment, AppointmentsRepo>> {
        private class testClass : PagedPage<AppointmentView, Appointment, AppointmentsRepo> {
            public testClass(AppointmentsRepo r) : base(r) { }
            protected override AppointmentView ToView(Appointment? entity) 
                => throw new System.NotImplementedException();
            protected override Appointment ToObject(AppointmentView? item)
                => throw new System.NotImplementedException();
        }
        protected override PagedPage<AppointmentView, Appointment, AppointmentsRepo> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new testClass(new AppointmentsRepo(db));
        }
        private HospitalWebAppDb? db;
        private AppointmentsRepo? r;
        private AppointmentsPage? p;
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            r = new AppointmentsRepo(db);
            p = new AppointmentsPage(r);
        }
        [TestMethod] public void PageIndexTest() => isProperty<int>();
        [TestMethod] public void GetValueTest() {
            var d = new AppointmentData() { PatientsId = "Henri" };
            var v = new AppointmentViewFactory().Create(new Appointment(d));
            var o = p?.GetValue(nameof(d.PatientsId), v);
            areEqual("Henri", o);
        }
        [TestMethod] public void DisplayNameTest() {
            var dName = new Appointment().GetType().GetProperties()[0].Name;
            var vName = new AppointmentView()?.GetType()?.GetProperty(dName)?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
            var dn = p?.DisplayName(dName);
            areEqual(vName, dn);
        }
        [TestMethod] public void TotalPagesTest() => areEqual(r.PageIndex = 5, p?.PageIndex);
        [TestMethod] public void HasNextPageTest() {
            var nr = addData();
            isNotNull(r);
            r.PageSize = 1;
            r.PageIndex = nr;
            areEqual(false, p?.HasNextPage);
            r.PageIndex = 0;
            areEqual(true, p?.HasNextPage);
        }
        private int addData() {
            var nr = GetRandom.Int32(2, 10);
            for (var i = 0; i < nr; i++) {
                db?.Appointments?.Add(GetRandom.Value<AppointmentData>());
                db?.SaveChanges();
            }
            return nr;
        }
        [TestMethod] public void HasPreviousPageTest() {
            _ = addData();
            isNotNull(r);
            r.PageSize = 1;
            r.PageIndex = 0;
            areEqual(false, p?.HasPreviousPage);
            r.PageIndex = 1;
            areEqual(true, p?.HasPreviousPage);
        }
        [TestMethod] public void IndexColumnsTest() {
            var ic = p?.IndexColumns;
            var d = new AppointmentData();
            var piL = new AppointmentData().GetType().GetProperties();
            var l = (from pi in piL where pi?.DeclaringType?.Name == d?.GetType().Name select pi.Name).ToList();
            foreach (var s in ic) isTrue(l.Contains(s));
        }
    }
}
