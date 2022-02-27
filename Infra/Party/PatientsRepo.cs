using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra.Party
{
    public class PatientsRepo : Repo<Patient, PatientData>, IPatientRepo {
        public PatientsRepo(DbContext c, DbSet<PatientData> s) : base(c, s) { }
        protected override Patient toDomain(PatientData d) => new Patient(d);
    }
}
