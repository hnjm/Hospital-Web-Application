#nullable disable
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMEHospitalWebApp.Pages.Patients
{
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class PatientsPage : PageModel
    {
        private readonly IPatientRepo repo;
        [BindProperty] public PatientView BindData { get; set; }
        public IList<PatientView> Patients { get; set; }
        public PatientsPage(ApplicationDbContext c) => repo = new PatientsRepo(c, c.Patients);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new PatientViewFactory().Create(BindData));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            BindData = await GetPatient(id);
            return BindData == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            BindData = await GetPatient(id);
            return BindData == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            BindData = await GetPatient(id);
            return BindData == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new PatientViewFactory().Create(BindData);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Patients = new List<PatientView>();
            foreach (var obj in list)
            {
                var v = new PatientViewFactory().Create(obj);
                Patients.Add(v);
            }
            return Page();
        }
        private async Task<PatientView> GetPatient(string id) 
            => new PatientViewFactory().Create(await repo.GetAsync(id));
    }
}
