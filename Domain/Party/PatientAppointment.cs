using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface IPatientAppointmentRepo : IRepo<PatientAppointment> { }
    public sealed class PatientAppointment : NamedEntity<PatientAppointmentData> {
        public PatientAppointment() : this(new PatientAppointmentData()) { }
        public PatientAppointment(PatientAppointmentData d) : base(d) { }
        public string PatientId => getValue(Data?.PatientId);
        public string AppointmentId => getValue(Data?.AppointmentId);
        public Patient? Patient => GetRepo.Instance<IPatientRepo>()?.Get(PatientId);
        public Appointment? Appointment => GetRepo.Instance<IAppointmentRepo>()?.Get(AppointmentId);
    }
}
