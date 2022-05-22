using System.ComponentModel;
using System.Reflection;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages {
    [TestClass] public class OrderedPageTests 
        : AbstractClassTests<OrderedPage<AppointmentView, Appointment, AppointmentsRepo>,
        FilteredPage<AppointmentView, Appointment, AppointmentsRepo>> {
        private class testClass : OrderedPage<AppointmentView, Appointment, AppointmentsRepo> {
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
        protected override OrderedPage<AppointmentView, Appointment, AppointmentsRepo> createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new testClass(new AppointmentsRepo(db));
        }
        private AppointmentsRepo? r;
        private AppointmentsPage? p;
        private string? dName;
        private string? vName;
        [TestInitialize] public void Init() {
            r = new AppointmentsRepo(GetRepo.Instance<HospitalWebAppDb>());
            p = new AppointmentsPage(r);
            dName = new Appointment().GetType().GetProperties()[0].Name;
            vName = new AppointmentView()?.GetType()?.GetProperty(dName)?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        }
        [TestMethod] public void CurrentOrderTest() {
            isNotNull(r);
            r.CurrentOrder = dName;
            areEqual(vName, p?.CurrentOrder);
            isNotNull(p);
            p.CurrentOrder = dName + "_desc";
            areEqual(vName + "_desc", p.CurrentOrder);
        }
        [TestMethod] public void SortOrderTest() {
            isNotNull(vName);
            isNotNull(p);
            var n = p.SortOrder(vName);
            areEqual(dName + "_desc", n);
        }
    }
}
