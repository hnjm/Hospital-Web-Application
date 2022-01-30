namespace EMEHospitalWebApp.Data
{
    public class Appointment
    {
        public string Id { get; set; }
        public string? PatientsId { get; set; }
        public string? DoctorsId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? DiagnosisId { get; set; }
    }
}
