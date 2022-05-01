using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData, NamedData> {
        [TestMethod] public void CountryIdTest() => isProperty<string>();
        [TestMethod] public void CurrencyIdTest() => isProperty<string>();
    }
}
