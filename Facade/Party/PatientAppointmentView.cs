using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party;

public class PatientAppointmentView : NamedView {
    [DisplayName("Patient")][Required] public string PatientId { get; set; } = string.Empty;
    [DisplayName("Appointment")][Required] public string AppointmentId { get; set; } = string.Empty;
    [DisplayName("Use for")] public new string? Code { get; set; }
}

public sealed class PatientAppointmentViewFactory : BaseViewFactory<PatientAppointmentView, PatientAppointment, PatientAppointmentData> {
    protected override PatientAppointment toEntity(PatientAppointmentData d) => new(d);
}
