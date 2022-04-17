using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMEHospitalWebApp.Pages.Party;

public class PatientAppointmentsPage : PagedPage<PatientAppointmentView, PatientAppointment, IPatientAppointmentRepo> {
    private readonly IAppointmentRepo appointment;
    private readonly IPatientRepo patient;
    public PatientAppointmentsPage(IPatientAppointmentRepo r, IAppointmentRepo a, IPatientRepo p) : base(r) {
        appointment = a;
        patient = p;
    }
    protected override PatientAppointment ToObject(PatientAppointmentView? item) => new PatientAppointmentViewFactory().Create(item);
    protected override PatientAppointmentView ToView(PatientAppointment? entity) => new PatientAppointmentViewFactory().Create(entity);
    public override string[] IndexColumns { get; } = {
        nameof(PatientAppointmentView.Code),
        nameof(PatientAppointmentView.Name),
        nameof(PatientAppointmentView.PatientId),
        nameof(PatientAppointmentView.AppointmentId),
        nameof(PatientAppointmentView.Description)
    };
    public IEnumerable<SelectListItem> Patients
        => patient?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();
    public IEnumerable<SelectListItem> Appointments
        => appointment?.GetAll(x => x.ToString())?.Select(x => new SelectListItem(x.ToString(), x.Id)) ?? new List<SelectListItem>();
    public string PatientName(string? patientId = null)
        => Patients?.FirstOrDefault(x => x.Value == (patientId ?? string.Empty))?.Text ?? "Undefined";
    public string AppointmentName(string? appointmentId = null)
        => Appointments?.FirstOrDefault(x => x.Value == (appointmentId ?? string.Empty))?.Text ?? "Undefined";
    public override object? GetValue(string name, PatientAppointmentView v) {
        var r = base.GetValue(name, v);
        return name == nameof(PatientAppointmentView.PatientId) ? PatientName(r as string)
            : name == nameof(PatientAppointmentView.AppointmentId) ? AppointmentName(r as string)
            : r;
    }
}