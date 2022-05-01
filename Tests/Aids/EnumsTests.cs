using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class EnumsTests : TypeTests {
        [TestMethod] public void DescriptionTest()
            => areEqual("Not applicable", IsoGender.NotApplicable.Description());
        [TestMethod] public void ToStringTest()
            => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
