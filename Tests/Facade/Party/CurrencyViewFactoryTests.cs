using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party { 
    [TestClass] public class CurrencyViewFactoryTests :
        ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData> {
        protected override Currency toObject(CurrencyData d) => new(d);
    }
}
