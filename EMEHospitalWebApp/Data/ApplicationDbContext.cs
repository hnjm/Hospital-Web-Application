using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EMEHospitalWebApp.Data.Appointment>? Appointment { get; set; }
        public DbSet<EMEHospitalWebApp.Data.Patient>? Patient { get; set; }
    }
}