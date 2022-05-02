using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests :
        ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData> {
        protected override Country toObject(CountryData d) => new(d);
    }
}
