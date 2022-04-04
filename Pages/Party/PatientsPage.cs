using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;

namespace EMEHospitalWebApp.Pages.Party {
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class PatientsPage : PagedPage<PatientView, Patient, IPatientRepo> {
        public PatientsPage(IPatientRepo r) : base(r) { }
        protected override Patient ToObject(PatientView? item) => new PatientViewFactory().Create(item);
        protected override PatientView ToView(Patient? entity) => new PatientViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = {
            nameof(PatientView.FullName),
            nameof(PatientView.FirstName),
            nameof(PatientView.LastName),
            nameof(PatientView.Gender),
            nameof(PatientView.BirthDate),
            nameof(PatientView.IdCode)
        };
    }
}
