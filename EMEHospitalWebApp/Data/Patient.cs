using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Data
{
    public class Patient
    {
      

        public string Id { get; set; }

        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        public string? Gender { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "ID code")]
        public string? IdCode { get; set; }
    }
}
