using System.Collections.Generic;
using System.Linq;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages.Party {
    [TestClass] public class PatientAppointmentsPageTests 
        : SealedBaseTests<PatientAppointmentsPage, PagedPage<PatientAppointmentView, PatientAppointment, IPatientAppointmentRepo>> {
        protected override PatientAppointmentsPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new PatientAppointmentsPage(new PatientAppointmentsRepo(db), new AppointmentsRepo(db), new PatientsRepo(db));
        }
        private HospitalWebAppDb? db;
        private PatientAppointmentsPage? p;
        private string id;
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            p = new PatientAppointmentsPage(new PatientAppointmentsRepo(db), new AppointmentsRepo(db), new PatientsRepo(db));
            id = "12321";
            db.Add(new PatientData() { Id = id, FirstName = "Henri", LastName = "Haugas" });
            db.Add(new PatientData() { FirstName = "Martin", LastName = "Herem" });
            db.Add(new AppointmentData() { Id = id, PatientsId = "Henri", DoctorsId = "Haugas" });
            db.Add(new AppointmentData() { PatientsId = "Martin", DoctorsId = "Herem" });
            db.Add(new PatientAppointmentData() { Id = id, PatientId = "Martin", AppointmentId = "Herem" });
            db.SaveChanges();
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void PatientNameTest() 
            => areEqual("Henri Haugas (Not applicable, 01.01.0001 00:00:00) ", p?.PatientName(id));
        [TestMethod] public void AppointmentNameTest() 
            => areEqual("Henri Haugas 01.01.0001 00:00:00 Undefined", p?.AppointmentName(id));
        [TestMethod] public void GetValueTest() {
            var d = new PatientAppointmentData() { PatientId = "12321", AppointmentId = "12321" };
            var v = new PatientAppointmentViewFactory().Create(new PatientAppointment(d));
            areEqual("Henri Haugas (Not applicable, 01.01.0001 00:00:00) ", p?.GetValue(nameof(d.PatientId), v));
            areEqual("Henri Haugas 01.01.0001 00:00:00 Undefined", p?.GetValue(nameof(d.AppointmentId), v));
        }
        [TestMethod] public void PatientsTest() {
            isTrue(p?.Patients?.Any(item => item.Text == "Henri Haugas (Not applicable, 01.01.0001 00:00:00) "));
            isTrue(p?.Patients?.Any(item => item.Text == "Martin Herem (Not applicable, 01.01.0001 00:00:00) "));
        }
        [TestMethod] public void AppointmentsTest() {
            isTrue(p?.Appointments?.Any(item => item.Text == "Henri Haugas 01.01.0001 00:00:00 Undefined"));
            isTrue(p?.Appointments?.Any(item => item.Text == "Martin Herem 01.01.0001 00:00:00 Undefined"));
        }
        [TestMethod] public void ErrorTest() {
            p?.ModelState.AddModelError("key", "error message");
            var d = new PatientAppointmentData() { Id = id, PatientId = "Martin", AppointmentId = "Herem", Code = "EST", Description = "Euro", Name = "Estonia", Token = new byte[] {1, 2}};
            var v = new PatientAppointmentViewFactory().Create(new PatientAppointment(d));
            p.Item = v;
            p.Items = new List<PatientAppointmentView>() { v };
            //p?.OnGetEditAsync(id);
        }
    }
}
