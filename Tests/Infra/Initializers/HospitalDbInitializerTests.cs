using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class HospitalDbInitializerTests : TypeTests {
        [TestMethod] public void InitTest() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            HospitalDbInitializer.Init(db);
            isNotNull(db?.Appointments);
            isNotNull(db?.Patients);
            isNotNull(db?.PatientAppointment);
            isNotNull(db?.Countries);
            isNotNull(db?.Currencies);
            isNotNull(db?.CountryCurrency);
        }
    }
}
