namespace EMEHospitalWebApp.Data
{
    public class Patient
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdCode { get; set; }
    }
}
