using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Infra;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HospitalWebAppDb(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<HospitalWebAppDb>>()))
            {
                if (context == null || context.Appointments == null || context.Patients == null)
                {
                    throw new ArgumentNullException("Null ApplicationDbContext");
                }

                //Look for any movies.
                if (context.Appointments.Any() && context.Patients.Any())
                {
                    return;   // DB has been seeded
                }

                if (!context.Appointments.Any())
                {
                    context.Appointments.AddRange(
                        new AppointmentData {Id = Guid.NewGuid().ToString(), PatientsId = "M.Herem", DoctorsId = "K.Laanet", DateTime = DateTime.Parse("2022-1-25 14:12:18"), DiagnosisId = "#224225"},
                        new AppointmentData {Id = Guid.NewGuid().ToString(), PatientsId = "H.Haugas", DoctorsId = "K.Jürgenson", DateTime = DateTime.Parse("2022-1-29 12:05:33"), DiagnosisId = "#224442"}
                    );
                }
                if (!context.Patients.Any())
                {
                    context.Patients.AddRange(
                        new PatientData {Id = Guid.NewGuid().ToString(), FirstName = "Mihkel", LastName = "Herem", BirthDate = DateTime.Parse("1973-12-17 10:15:57"), Gender = "Male", IdCode = "40044028135"},
                        new PatientData {Id = Guid.NewGuid().ToString(), FirstName = "Harri", LastName = "Haugas", BirthDate = DateTime.Parse("2002-10-5 14:18:49"), Gender = "Male", IdCode = "50539245821"
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
