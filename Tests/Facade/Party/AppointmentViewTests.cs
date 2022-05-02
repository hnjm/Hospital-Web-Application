using System;
using EMEHospitalWebApp.Facade;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewTests : SealedClassTests<AppointmentView, UniqueView> {
        [TestMethod] public void PatientsIdTest() => isRequired<string?>("Patients ID");
        [TestMethod] public void DoctorsIdTest() => isRequired<string?>("Doctors ID");
        [TestMethod] public void DateTimeTest() => isDisplayNamed<DateTime?>("Date of appointment");
        [TestMethod] public void DiagnosisIdTest() => isDisplayNamed<string?>("Diagnosis ID");
        [TestMethod] public void PatientTest() => isDisplayNamed<string?>("Patients ID Code");
    }
}
