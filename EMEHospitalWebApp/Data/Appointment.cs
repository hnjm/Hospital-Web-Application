using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMEHospitalWebApp.Data
{
    public class Appointment
    {
        public string Id { get; set; }

        [Display(Name = "Patients ID")]
        public string? PatientsId { get; set; }

        [Display(Name = "Doctors ID")]
        public string? DoctorsId { get; set; }

        [Display(Name = "Date of appointment")]
        public DateTime? DateTime { get; set; }

        [Display(Name = "Diagnosis ID")]
        public string? DiagnosisId { get; set; }
    }
}
