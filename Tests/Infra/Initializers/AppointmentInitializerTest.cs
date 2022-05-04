using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class AppointmentsInitializerTests
        : SealedBaseTests<AppointmentsInitializer, BaseInitializer<AppointmentData>> {
        protected override AppointmentsInitializer createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new AppointmentsInitializer(db);
        }
    }
}
