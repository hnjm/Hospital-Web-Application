using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party {
    public sealed class PatientView : UniqueView {
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Gender")] public string? Gender { get; set; }
        [DisplayName("Birth Date")] public DateTime? BirthDate { get; set; }
        [DisplayName("ID code")] public string? IdCode { get; set; }
        [DisplayName("Country")] public string? Country { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }

    public sealed class PatientViewFactory : BaseViewFactory<PatientView, Patient, PatientData> {
        protected override Patient ToEntity(PatientData d) => new(d);
        public override PatientView Create(Patient? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
