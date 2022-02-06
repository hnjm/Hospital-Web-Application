using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMEHospitalWebApp.Facade.Party
{
    public class PatientView
    {
        [Required] public string Id { get; set; }
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Gender")] public string? Gender { get; set; }
        [DisplayName("Birth Date")] public DateTime? BirthDate { get; set; }
        [DisplayName("ID code")] public string? IdCode { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
}
