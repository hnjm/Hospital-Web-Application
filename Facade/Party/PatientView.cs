using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party {
    public sealed class PatientView : UniqueView {
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Gender")] public IsoGender? Gender { get; set; }
        [DisplayName("Birth Date")] public DateTime? BirthDate { get; set; }
        [DisplayName("ID code")] public string? IdCode { get; set; }
        [DisplayName("Country Id")] public string? CountryId { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }

    public sealed class PatientViewFactory : BaseViewFactory<PatientView, Patient, PatientData> {
        protected override Patient toEntity(PatientData d) => new(d);
        public override Patient Create(PatientView? v) {
            v ??= new PatientView();
            v.Gender ??= IsoGender.NotApplicable;
            return base.Create(v);
        }
        public override PatientView Create(Patient? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Gender = e?.Gender;
            return v;
        }
    }
}
