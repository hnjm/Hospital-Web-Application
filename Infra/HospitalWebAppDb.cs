using EMEHospitalWebApp.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra {
    public sealed class HospitalWebAppDb : DbContext {
        public HospitalWebAppDb(DbContextOptions<HospitalWebAppDb> options) : base(options) { }
        public DbSet<AppointmentData>? Appointments { get; set; }
        public DbSet<PatientData>? Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(HospitalWebAppDb)[..^2];
            _ = b?.Entity<AppointmentData>()?.ToTable(nameof(Appointments), s);
            _ = b?.Entity<PatientData>()?.ToTable(nameof(Patients), s);
        }
    }
}
