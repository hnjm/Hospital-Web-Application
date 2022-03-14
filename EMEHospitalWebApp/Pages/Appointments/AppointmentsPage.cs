#nullable disable
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMEHospitalWebApp.Pages.Appointments {
    public class AppointmentsPage : PageModel {
        private readonly IAppointmentRepo repo;
        [BindProperty] public AppointmentView Item { get; set; }
        public IList<AppointmentView> Items { get; set; }
        public AppointmentsPage(HospitalWebAppDb c) => repo = new AppointmentsRepo(c, c.Appointments);
        public IActionResult OnGetCreate() => Page();
        public string ItemId => Item?.Id ?? string.Empty;
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new AppointmentViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await GetAppointment(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await GetAppointment(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await GetAppointment(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = new AppointmentViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<AppointmentView>();
            foreach (var obj in list)
            {
                var v = new AppointmentViewFactory().Create(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<AppointmentView> GetAppointment(string id)
            => new AppointmentViewFactory().Create(await repo.GetAsync(id));
    }
}
