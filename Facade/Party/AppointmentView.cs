using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Facade.Party
{
    public class AppointmentView
    {
        [Required] public string Id { get; set; }
        [Display(Name = "Patients ID")] [Required] public string? PatientsId { get; set; }
        [Display(Name = "Doctors ID")] [Required] public string? DoctorsId { get; set; }
        [Display(Name = "Date of appointment")] public DateTime? DateTime { get; set; }
        [Display(Name = "Diagnosis ID")] public string? DiagnosisId { get; set; }
    }
}
