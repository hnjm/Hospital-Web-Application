using System.ComponentModel.DataAnnotations;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party {
    public sealed class AppointmentView : UniqueView {
        [Display(Name = "Patients ID")] [Required] public string? PatientsId { get; set; }
        [Display(Name = "Doctors ID")] [Required] public string? DoctorsId { get; set; }
        [Display(Name = "Date of appointment")] public DateTime? DateTime { get; set; }
        [Display(Name = "Diagnosis ID")] public string? DiagnosisId { get; set; }
    }

    public sealed class AppointmentViewFactory : BaseViewFactory<AppointmentView, Appointment, AppointmentData> {
        protected override Appointment ToEntity(AppointmentData d) => new(d);
    }
}
