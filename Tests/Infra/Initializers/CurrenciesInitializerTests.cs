using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Initializers{
    [TestClass] public class CurrenciesInitializerTests 
        : SealedBaseTests<CurrenciesInitializer, BaseInitializer<CurrencyData>> {
        protected override CurrenciesInitializer createObj() {
            var db = GetRepo.Instance<HospitalWebAppDb>();
            return new CurrenciesInitializer(db);
        }
    }
}
