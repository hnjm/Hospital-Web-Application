#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly EMEHospitalWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(EMEHospitalWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patient.FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
