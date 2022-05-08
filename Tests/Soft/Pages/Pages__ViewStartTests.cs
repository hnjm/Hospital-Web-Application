using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages {
    [TestClass] public class Pages__ViewStartTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> { }
}
