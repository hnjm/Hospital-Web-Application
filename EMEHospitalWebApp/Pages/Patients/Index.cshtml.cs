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
    public class IndexModel : PageModel
    {
        private readonly EMEHospitalWebApp.Data.ApplicationDbContext _context;

        public IndexModel(EMEHospitalWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patient.ToListAsync();
        }
    }
}
