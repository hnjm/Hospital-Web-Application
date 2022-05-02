using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, NamedView> {
        [TestMethod] public void CountryIdTest() => isRequired<string>("Country");
        [TestMethod] public void CurrencyIdTest() => isRequired<string>("Currency");
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Currency native code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Currency native name");
    }
}
