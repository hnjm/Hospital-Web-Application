using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public sealed class PatientAppointmentRepo : Repo<PatientAppointment, PatientAppointmentData>, IPatientAppointmentRepo {
        public PatientAppointmentRepo(HospitalWebAppDb? db) : base(db, db?.PatientAppointment) { }
        protected internal override PatientAppointment toDomain(PatientAppointmentData d) => new(d);
        internal override IQueryable<PatientAppointmentData> addFilter(IQueryable<PatientAppointmentData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                    x => x.Id.Contains(y)
                         || x.PatientId.Contains(y)
                         || x.AppointmentId.Contains(y)
                         || x.Name.Contains(y)
                         || x.Code.Contains(y)
                         || x.Description.Contains(y));
        }
    }

}
