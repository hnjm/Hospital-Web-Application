using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class PatientViewFactoryTests : SealedClassTests<PatientViewFactory, BaseViewFactory<PatientView, Patient, PatientData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<PatientData>();
            var e = new Patient(d);
            var v = new PatientViewFactory().Create(e);
            isNotNull(v);
            //areEqualProperties(v, e, nameof(v.FullName));
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.BirthDate, e.BirthDate);
            areEqual(v.IdCode, e.IdCode);
            areEqual(v.CountryId, e.CountryId);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<PatientView>() as PatientView;
            var e = new PatientViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
