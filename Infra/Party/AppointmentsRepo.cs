using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra.Party
{
    public class AppointmentsRepo : Repo<Appointment, AppointmentData>, IAppointmentRepo {
        public AppointmentsRepo(DbContext c, DbSet<AppointmentData> s) : base(c, s) { }
        protected override Appointment toDomain(AppointmentData d) => new Appointment(d);
    }
}
