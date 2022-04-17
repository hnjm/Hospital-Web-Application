using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party;

public interface IPatientAppointmentRepo : IRepo<PatientAppointment> { }
public class PatientAppointment : NamedEntity<PatientAppointmentData> {
    public PatientAppointment() : this(new PatientAppointmentData()) { }
    public PatientAppointment(PatientAppointmentData d) : base(d) { }
    public string PatientId => getValue(Data?.PatientId);
    public string AppointmentId => getValue(Data?.AppointmentId);
}
