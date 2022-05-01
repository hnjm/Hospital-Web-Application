using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft {
    [TestClass] public class IsSoftTested : AssemblyTests
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"EHEHospitalWebApp.Sentry\"");
    }
}
