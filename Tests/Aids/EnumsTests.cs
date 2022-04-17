using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass]
    public class EnumsTests : IsTypeTested {
        [TestMethod] public void DescriptionTest()
            => AreEqual("Not applicable", IsoGender.NotApplicable.Description());
        [TestMethod] public void ToStringTest()
            => AreEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
