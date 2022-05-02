using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class PatientAppointmentViewTests : SealedClassTests<PatientAppointmentView, NamedView> {
        [TestMethod] public void PatientIdTest() => isRequired<string>("Patient");
        [TestMethod] public void AppointmentIdTest() => isRequired<string>("Appointment");
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Use for");
    }
}
