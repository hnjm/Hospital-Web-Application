using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers {
    [TestClass] public class CountryCurrenciesInitializerTests
        : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
}
