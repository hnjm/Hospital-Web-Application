using System;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Domain {
    [TestClass] public class GetRepoTests : TypeTests {
        private class testClass : IServiceProvider {
            public object? GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod] public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<ICountriesRepo>(), typeof(CountriesRepo));
        [TestMethod] public void SetServiceTest() {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
