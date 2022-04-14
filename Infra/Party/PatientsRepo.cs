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
                x => contains(x.FirstName, y)
                     || contains(x.LastName, y)
                     || contains(x.Id, y)
                     || contains(x.Gender, y)
                     || contains(x.IdCode, y)
                     || contains(x.Country, y)
                     || contains(x.BirthDate.ToString(), y));
        }
    }
}
