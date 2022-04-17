namespace EMEHospitalWebApp.Data.Party {
    public sealed class PatientAppointmentData : NamedData {
        public string PatientId { get; set; } = string.Empty;
        public string AppointmentId { get; set; } = string.Empty;
    }
}
