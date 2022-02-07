#nullable disable
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Pages.Appointments
{
    public class AppointmentsPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public AppointmentView Appointment { get; set; }
        public IList<AppointmentView> Appointments { get; set; }
        public AppointmentsPage(ApplicationDbContext c) => context = c;
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

            var d = new AppointmentViewFactory().Create(Appointment).Data;
            context.Appointments.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Appointment = await GetAppointment(id);
            return Appointment == null ? NotFound() : Page();
        }
        private async Task<AppointmentView> GetAppointment(string id)
        {
            if (id == null) return null;
            var d = await context.Appointments.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;

            return new AppointmentViewFactory().Create(new Appointment(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Appointment = await GetAppointment(id);
            return Appointment == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Appointments.FindAsync(id);

            if (d != null)
            {
                context.Appointments.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Appointment = await GetAppointment(id);
            return Appointment == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new AppointmentViewFactory().Create(Appointment).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Appointment.Id))
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
        private bool PatientExists(string id) => context.Appointments.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            var list = await context.Appointments.ToListAsync();
            Appointments = new List<AppointmentView>();
            foreach (var d in list)
            {
                var v = new AppointmentViewFactory().Create(new Appointment(d));
                Appointments.Add(v);
            }
        }
    }
}
