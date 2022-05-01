using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Data;

[TestClass] public class IsoGenderTests : TypeTests {
    [TestMethod] public void MaleTest() => doTest(IsoGender.Male, 1, "Male");
    [TestMethod] public void FemaleTest() => doTest(IsoGender.Female, 2, "Female");
    [TestMethod] public void NotKnownTest() => doTest(IsoGender.NotKnown, 0, "Not known");
    [TestMethod] public void NotApplicableTest() => doTest(IsoGender.NotApplicable, 9, "Not applicable");
    private static void doTest(IsoGender isoGender, int value, string description) {
        areEqual(value, (int) isoGender);
        areEqual(description, isoGender.Description());
    }
}
