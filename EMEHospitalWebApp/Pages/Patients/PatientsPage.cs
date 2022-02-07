#nullable disable
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Pages.Patients
{
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class PatientsPage : PageModel
    {
        private readonly ApplicationDbContext context;
        
        [BindProperty]
        public PatientView Patient { get; set; }
        public IList<PatientView> Patients { get; set; }
        public PatientsPage(ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PatientViewFactory().Create(Patient).Data;
            context.Patients.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Patient = await GetPatient(id);
            return Patient == null ? NotFound() : Page();
        }
        private async Task<PatientView> GetPatient(string id)
        {
            if (id == null) return null;
            var d = await context.Patients.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
       
            return new PatientViewFactory().Create(new Patient(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Patient = await GetPatient(id);
            return Patient == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Patients.FindAsync(id);

            if (d != null)
            {
                context.Patients.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Patient = await GetPatient(id);
            return Patient == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PatientViewFactory().Create(Patient).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "Index");
        }
        private bool PatientExists(string id) => 
            context.Patients.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            var list = await context.Patients.ToListAsync();
            Patients = new List<PatientView>();
            foreach (var d in list)
            {
                var v = new PatientViewFactory().Create(new Patient(d));
                Patients.Add(v);
            }
        }
    }
}
