using System.Linq;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using EMEHospitalWebApp.Infra.Party;
using EMEHospitalWebApp.Pages;
using EMEHospitalWebApp.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Pages.Party {
    [TestClass] public class PatientsPageTests : SealedBaseTests<PatientsPage, PagedPage<PatientView, Patient, IPatientRepo>> {
        protected override PatientsPage createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new PatientsPage(new PatientsRepo(db), new CountriesRepo(db));
        }
        private HospitalWebAppDb? db;
        private PatientsPage? p;
        [TestInitialize] public void Init() {
            db = GetRepo.Instance<HospitalWebAppDb>();
            p = new PatientsPage(new PatientsRepo(db), new CountriesRepo(db));
            HospitalDbInitializer.Init(db);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountryNameTest() {
            var d = db?.Countries?.FirstOrDefault();
            var cn = p?.CountryName(d?.Id);
            areEqual(d?.Name, cn);
        }
        [DataRow(IsoGender.NotKnown, "Not known")]
        [DataRow(IsoGender.Male, "Male")]
        [DataRow(IsoGender.Female, "Female")]
        [DataRow(IsoGender.NotApplicable, "Not applicable")]
        [TestMethod] public void GenderDescriptionTest(IsoGender gender, string expected) 
            => areEqual(expected, p?.GenderDescription(gender));
        [TestMethod] public void GetValueTest() {
            var d = new PatientData { Gender = IsoGender.Male, CountryId = "EST" };
            var v = new PatientViewFactory().Create(new Patient(d));
            areEqual("Male", p?.GetValue(nameof(d.Gender), v));
            areEqual("Estonia", p?.GetValue(nameof(d.CountryId), v));
        }
        [TestMethod] public void CountriesTest() 
            => areEqual(db?.Countries?.Count(), p?.Countries?.Count());
        
        [DataRow("Not known")]
        [DataRow("Male")]
        [DataRow("Female")]
        [DataRow("Not applicable")]
        [TestMethod] public void GendersTest(string gender) 
            => isTrue(p?.Genders?.Any(item => item.Text == gender));
    }
}
