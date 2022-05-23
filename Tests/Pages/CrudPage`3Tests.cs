using System.Linq;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EMEHospitalWebApp.Tests.Pages {
    [TestClass] public class CrudPageTests
        : AbstractClassTests<CrudPage<AppointmentView, Appointment, AppointmentsRepo>,
            BasePage<AppointmentView, Appointment, AppointmentsRepo>> {
        private class testClass : CrudPage<AppointmentView, Appointment, AppointmentsRepo> {
            public testClass(AppointmentsRepo r) : base(r) { }
            protected override AppointmentView ToView(Appointment? entity) 
                => throw new System.NotImplementedException();
            protected override Appointment ToObject(AppointmentView? item)
                => throw new System.NotImplementedException();
            protected override IActionResult redirectToIndex()
                => throw new System.NotImplementedException();
            protected override IActionResult redirectToEdit(AppointmentView v)
                => throw new System.NotImplementedException();
            protected override IActionResult redirectToDelete(string id)
                => throw new System.NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order)
                => throw new System.NotImplementedException();
        }
        protected override CrudPage<AppointmentView, Appointment, AppointmentsRepo> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new testClass(new AppointmentsRepo(db));
        }
        private HospitalWebAppDb? db;
        private AppointmentsPage? p;
        private AppointmentData? d;
        private int testIdx = 2;
        private string testIdStr = "123";
        private string testFilterStr = "Name";
        private string testOrderStr = "_desc";
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            p = new AppointmentsPage(new AppointmentsRepo(db)) { TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>()) };
            d = new AppointmentData() { Id = testIdStr, Token = new byte[] { 1, 2 }, DiagnosisId = "a" };
            db?.Add(d);
            db?.SaveChanges();
        }
        [TestMethod] public void SuccessfulEditTest() => isTrue(postCreate(new byte[] { 1, 2 }, "b"));
        [TestMethod] public void ConcurrencyEditTest() {
            postCreate(new byte[] {1, 3});
            p?.OnGetEditAsync(testIdStr);
            isTrue(!p?.ModelState.IsValid);
        }
        private bool? postCreate(byte[] token, string? di = null) {
            var dX = new AppointmentData() { Id = testIdStr, Token = token, DiagnosisId = di };
            isNotNull(p);
            p.Item = new AppointmentViewFactory().Create(new Appointment(dX)); 
            p?.OnPostEditAsync();
            return db?.Appointments?.Contains(dX);
        }
        [TestMethod] public void SuccessfulDeleteTest() => isFalse(postDelete("12"));
        [TestMethod] public void ConcurrencyDeleteTest() => isTrue(postDelete("13"));
        private bool? postDelete(string token) {
            isNotNull(db);
            isNotNull(d);
            if (!(db?.Appointments?.Contains(d) ?? false)) { db?.Add(d); db?.SaveChanges(); };
            p?.OnPostDeleteAsync(testIdStr, testIdx, testFilterStr, testOrderStr, token);
            return db?.Appointments?.Contains(d);
        }
    }
}
