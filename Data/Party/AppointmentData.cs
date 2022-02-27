namespace EMEHospitalWebApp.Data.Party
{
    public class AppointmentData : EntityData {
        public string? PatientsId { get; set; }
        public string? DoctorsId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? DiagnosisId { get; set; }
    }
}
