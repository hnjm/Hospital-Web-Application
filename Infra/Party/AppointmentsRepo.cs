using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party {
    public class AppointmentsRepo : Repo<Appointment, AppointmentData>, IAppointmentRepo {
        public AppointmentsRepo(HospitalWebAppDb? db) : base(db, db?.Appointments) { }
        protected override Appointment ToDomain(AppointmentData d) => new Appointment(d);
    }
}
