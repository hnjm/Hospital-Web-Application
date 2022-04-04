using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public class PatientsRepo : Repo<Patient, PatientData>, IPatientRepo {
        public PatientsRepo(HospitalWebAppDb? db) : base(db, db?.Patients) { }
        protected override Patient ToDomain(PatientData d) => new Patient(d);
        internal override IQueryable<PatientData> addFilter(IQueryable<PatientData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.FirstName.Contains(y)
                     || x.LastName.Contains(y)
                     || x.Id.Contains(y)
                     || x.Gender.Contains(y)
                     || x.IdCode.Contains(y)
                     || x.BirthDate.ToString().Contains(y));
        }
    }
}
