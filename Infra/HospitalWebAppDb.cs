using EMEHospitalWebApp.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra {
    public sealed class HospitalWebAppDb : DbContext {
        public HospitalWebAppDb(DbContextOptions<HospitalWebAppDb> options) : base(options) { }
        public DbSet<AppointmentData>? Appointments { get; set; }
        public DbSet<PatientData>? Patients { get; set; }
        public DbSet<CountryData>? Countries { get; set; }
        public DbSet<CurrencyData>? Currencies { get; set; }
        public DbSet<CountryCurrencyData>? CountryCurrency { get; set; }
        public DbSet<PatientAppointmentData>? PatientAppointment { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(HospitalWebAppDb)[..^2];
            _ = b?.Entity<AppointmentData>()?.ToTable(nameof(Appointments), s);
            _ = b?.Entity<PatientData>()?.ToTable(nameof(Patients), s);
            _ = b?.Entity<CountryData>()?.ToTable(nameof(Countries), s);
            _ = b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s);
            _ = b?.Entity<CountryCurrencyData>()?.ToTable(nameof(CountryCurrency), s);
            _ = b?.Entity<PatientAppointmentData>()?.ToTable(nameof(PatientAppointment), s);
        }
    }
}
