namespace EMEHospitalWebApp.Data.Party
{
    public sealed class AppointmentData : UniqueData {
        public string? PatientsId { get; set; }     
        public string? DoctorsId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? DiagnosisId { get; set; }
    }
}
