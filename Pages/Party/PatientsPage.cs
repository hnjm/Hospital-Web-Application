using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMEHospitalWebApp.Pages.Party {
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    [Authorize]
    public class PatientsPage : PagedPage<PatientView, Patient, IPatientRepo> {
        private readonly ICountriesRepo countries;
        public PatientsPage(IPatientRepo r, ICountriesRepo c) : base(r) => countries = c;
        protected override Patient ToObject(PatientView? item) => new PatientViewFactory().Create(item);
        protected override PatientView ToView(Patient? entity) => new PatientViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = {
            nameof(PatientView.FullName),
            nameof(PatientView.FirstName),
            nameof(PatientView.LastName),
            nameof(PatientView.Gender),
            nameof(PatientView.BirthDate),
            nameof(PatientView.IdCode),
            nameof(PatientView.CountryId)
        };
        public IEnumerable<SelectListItem> Countries
            => countries?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.Id)) ?? new List<SelectListItem>();
        public string CountryName(string? countryId = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryId ?? string.Empty))?.Text ?? "Undefined";
        public IEnumerable<SelectListItem> Genders
            => Enum.GetValues<IsoGender>()?.Select(x => new SelectListItem(x.Description(), x.ToString())) ?? new List<SelectListItem>();
        public string GenderDescription(IsoGender? x)
            => (x ?? IsoGender.NotApplicable).Description();
        public override object? GetValue(string name, PatientView v) {
            var r = base.GetValue(name, v);
            return name == nameof(PatientView.CountryId) ? CountryName(r as string)
                : name == nameof(PatientView.Gender) ? GenderDescription((IsoGender)r)
                : r;
        }
    }
}
