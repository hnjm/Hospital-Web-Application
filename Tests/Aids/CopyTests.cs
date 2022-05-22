using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class CopyTests : TypeTests {
        [TestMethod] public void PropertiesTest() {
            var v = GetRandom.Value<AppointmentView>();
            var d = new AppointmentData();
            Copy.Properties(v, d);
            areEqual(v?.Id, d.Id);
            areEqual(v?.PatientsId, d.PatientsId);
            areEqual(v?.DoctorsId, d.DoctorsId);
            areEqual(v?.DateTime, d.DateTime);
        }
    }
}
