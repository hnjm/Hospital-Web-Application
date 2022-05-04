using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public sealed class AppointmentsRepo : Repo<Appointment, AppointmentData>, IAppointmentRepo {
        public AppointmentsRepo(HospitalWebAppDb? db) : base(db, db?.Appointments) { }
        protected internal override Appointment toDomain(AppointmentData d) => new(d);
        internal override IQueryable<AppointmentData> addFilter(IQueryable<AppointmentData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                    x => x.Id.Contains(y) 
                         || x.PatientsId.Contains(y) 
                         || x.DoctorsId.Contains(y) 
                         || x.DateTime.ToString().Contains(y)
                         || x.DiagnosisId.Contains(y));
        }
    }
}
