#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly EMEHospitalWebApp.Data.ApplicationDbContext _context;

        public IndexModel(EMEHospitalWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var patient = from m in _context.Appointment
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                patient = patient.Where(s => s.PatientsId.Contains(SearchString));
            }

            Appointment = await patient.ToListAsync();
        }
    }
}
