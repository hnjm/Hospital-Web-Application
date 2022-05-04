using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Party {
    [TestClass] public class CurrenciesBaseTests
        : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>, Currency, CurrencyData> {
        protected override CurrenciesRepo createObj() => new(GetRepo.Instance<HospitalWebAppDb>());
        protected override object? getSet(HospitalWebAppDb db) => db.Currencies;
    }
}
