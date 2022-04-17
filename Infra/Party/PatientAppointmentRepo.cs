using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Infra.Party;

public class PatientAppointmentRepo : Repo<PatientAppointment, PatientAppointmentData>, IPatientAppointmentRepo {
    public PatientAppointmentRepo(HospitalWebAppDb? db) : base(db, db?.PatientAppointment) { }
    protected override PatientAppointment ToDomain(PatientAppointmentData d) => new(d);
    internal override IQueryable<PatientAppointmentData> addFilter(IQueryable<PatientAppointmentData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => x.PatientId.Contains(y)
                     || x.AppointmentId.Contains(y));
    }
}
