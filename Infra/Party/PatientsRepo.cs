using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public class PatientsRepo : Repo<Patient, PatientData>, IPatientRepo {
        public PatientsRepo(HospitalWebAppDb? db) : base(db, db?.Patients) { }
        protected override Patient ToDomain(PatientData d) => new(d);
        internal override IQueryable<PatientData> addFilter(IQueryable<PatientData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.FirstName.Contains(y)
                     || x.LastName.Contains(y)
                     || x.Id.Contains(y)
                     || x.Gender.ToString().Contains(y)
                     || x.IdCode.Contains(y)
                     || x.CountryId.Contains(y)
                     || x.BirthDate.ToString().Contains(y));
        }
    }
}
