using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class PatientsInitializerTests
        : SealedBaseTests<PatientsInitializer, BaseInitializer<PatientData>> {
        protected override PatientsInitializer createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new PatientsInitializer(db);
        }
    }
}
