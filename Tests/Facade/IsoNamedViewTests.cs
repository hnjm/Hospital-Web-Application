using EMEHospitalWebApp.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade {
    [TestClass] public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView> {
        private class testClass : IsoNamedView { }
        protected override IsoNamedView createObj() => new testClass();
        [TestMethod] public void CodeTest() => isRequired<string>("ISO three-letter code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("English name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("Native name");
    }
}
