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
        public static void InitializeTables(ModelBuilder b) {
            b?.Entity<AppointmentData>()?.ToTable(nameof(Appointments), nameof(HospitalWebAppDb).Substring(0, 17));
            b?.Entity<PatientData>()?.ToTable(nameof(Patients), nameof(HospitalWebAppDb).Substring(0, 17));
        }
    }
}
