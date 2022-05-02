using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class CountryCurrencyViewFactoryTests :
        ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toObject(CountryCurrencyData d) => new(d);
    }
}
