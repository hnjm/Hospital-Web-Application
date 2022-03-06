using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft {
    [TestClass] public class IsSoftTested : IsAssemblyTested
    {
        protected override void isAllTested() => IsInconclusive("Namespace has to be changed to \"EHEHospitalWebApp.Sentry\"");
    }
}
