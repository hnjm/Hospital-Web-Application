using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class CountriesInitializerTests
        : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>> {
        protected override CountriesInitializer createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CountriesInitializer(db);
        }
    }
}
