using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData> {
        [TestMethod] public void CountryIdTest() => IsProperty<string>();
        [TestMethod] public void CurrencyIdTest() => IsProperty<string>();
    }
}
