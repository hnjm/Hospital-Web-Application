using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Infra.Party {
    [TestClass] public class PatientAppointmentsRepoTests
        : SealedRepoTests<PatientAppointmentsRepo, Repo<PatientAppointment, PatientAppointmentData>, PatientAppointment, PatientAppointmentData> {
        protected override PatientAppointmentsRepo createObj() => new(GetRepo.Instance<HospitalWebAppDb>());
        protected override object? getSet(HospitalWebAppDb db) => db.PatientAppointment;
    }
}
