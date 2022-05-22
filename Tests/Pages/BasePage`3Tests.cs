using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages {
    [TestClass] public class BasePageTests 
        : AbstractClassTests<BasePage<AppointmentView, Appointment, AppointmentsRepo>, PageModel> {
        private class testClass : BasePage<AppointmentView, Appointment, AppointmentsRepo> {
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
            protected override IActionResult getCreate() 
                => throw new System.NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order)
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> postCreateAsync()
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> getDetailsAsync(string id)
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> getDeleteAsync(string id)
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> postDeleteAsync(string id, string? token = null)
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> getEditAsync(string id)
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> postEditAsync()
                => throw new System.NotImplementedException();
            protected override Task<IActionResult> getIndexAsync()
                => throw new System.NotImplementedException();
        }
        protected override BasePage<AppointmentView, Appointment, AppointmentsRepo> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new testClass(new AppointmentsRepo(db));
        }
        private HospitalWebAppDb? db;
        private AppointmentView? v;
        private AppointmentsPage? p;
        private int testIdx = 2;
        private string testIdStr = "123";
        private string testFilterStr = "Name";
        private string testOrderStr = "_desc";
        [TestInitialize] public void Init() {
            var d = new AppointmentData() { Id = "123", Token = new byte[] { 1, 2 } };
            db = GetRepo.Instance<HospitalWebAppDb>();
            db?.Add(d);
            db?.SaveChanges();
            v = new AppointmentViewFactory().Create(new Appointment(d));
            p = new AppointmentsPage(new AppointmentsRepo(db));
        }
        [TestMethod] public void ErrorMessageTest() => isProperty<string?>();
        [TestMethod] public void ItemTest() => isProperty<AppointmentView>();
        [TestMethod] public void ItemsTest() => isProperty<IList<AppointmentView>>();
        [TestMethod] public void ItemIdTest() {
            isNotNull(v);
            isNotNull(p);
            p.Item = v;
            areEqual(v.Id, p.ItemId);
        }
        [TestMethod] public void TokenTest() {
            isNotNull(v);
            isNotNull(p);
            p.Item = v;
            var s = v.Token.Aggregate(string.Empty, (current, b) => current + b);
            areEqual(s, p.Token);
        }
        private void checkIfSavedProperties(dynamic? a) {
            isNotNull(p);
            areEqual(testIdx, p.PageIndex);
            areEqual(testFilterStr, p.CurrentFilter);
            areEqual(testOrderStr, p.CurrentOrder);
        }
        [TestMethod] public void OnGetCreateTest() => checkIfSavedProperties(p?.OnGetCreate(testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnGetDetailsAsyncTest() => checkIfSavedProperties(p?.OnGetDetailsAsync(testIdStr, testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnPostCreateAsyncTest() => checkIfSavedProperties(p?.OnPostCreateAsync(testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnGetEditAsyncTest() => checkIfSavedProperties(p?.OnGetEditAsync(testIdStr, testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnPostEditAsyncTest() => checkIfSavedProperties(p?.OnPostEditAsync(testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnGetDeleteAsyncTest() => checkIfSavedProperties(p?.OnGetDeleteAsync(testIdStr, testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnPostDeleteAsyncTest() => checkIfSavedProperties(p?.OnPostDeleteAsync(testIdStr, testIdx, testFilterStr, testOrderStr));
        [TestMethod] public void OnGetIndexAsyncTest() => checkIfSavedProperties(p?.OnGetIndexAsync(testIdx, testFilterStr, testOrderStr));
    }
}
