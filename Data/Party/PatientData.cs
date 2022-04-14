namespace EMEHospitalWebApp.Data.Party
{
    public sealed class PatientData : UniqueData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdCode { get; set; }
        public string? Country { get; set; }
    }
}
