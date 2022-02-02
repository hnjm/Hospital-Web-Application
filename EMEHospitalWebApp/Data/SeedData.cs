using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Appointment == null)
                {
                    throw new ArgumentNullException("Null ApplicationDbContext");
                }

                //Look for any movies.
                if (context.Appointment.Any())
                {
                    return;   // DB has been seeded
                }

                context.Appointment.AddRange(
                    new Appointment
                    {
                        Id = Guid.NewGuid().ToString(),
                        PatientsId = "Elina",
                        DoctorsId = "Holger",
                        DateTime = DateTime.Parse("2022-8-4"),
                        DiagnosisId = "Too smart"
                    },
                    new Appointment
                    {
                        Id = Guid.NewGuid().ToString(),
                        PatientsId = "Henri",
                        DoctorsId = "Karmo",
                        DateTime = DateTime.Parse("2022-4-8"),
                        DiagnosisId = "Something else"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
