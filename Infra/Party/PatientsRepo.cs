using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public class PatientsRepo : Repo<Patient, PatientData>, IPatientRepo {
        public PatientsRepo(HospitalWebAppDb? db) : base(db, db?.Patients) { }
        protected override Patient ToDomain(PatientData d) => new Patient(d);
    }
}
