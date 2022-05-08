using System;
using System.Linq;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMEHospitalWebApp.Tests {
    public class TestHost<TProgram> : WebApplicationFactory<TProgram> where TProgram : class {
        public string Environment { get; set; } = "Development";
        protected override void ConfigureWebHost(IWebHostBuilder b) {
            base.ConfigureWebHost(b);
            b.ConfigureTestServices(s => {
                removeDb<ApplicationDbContext>(s);
                removeDb<HospitalWebAppDb>(s);
                s.AddEntityFrameworkInMemoryDatabase();
                addDb<ApplicationDbContext>(s);
                addDb<HospitalWebAppDb>(s);
                ensureCreated(s, typeof(ApplicationDbContext), typeof(HospitalWebAppDb));
            });
            b.UseEnvironment(Environment);
        }
        private static void ensureCreated(IServiceCollection s, params Type[] types) {
            s.AddRazorPages(o => {
                o.Conventions.AllowAnonymousToPage("/Appointments/Index");
                o.Conventions.AllowAnonymousToPage("/Appointments/Create");
                o.Conventions.AllowAnonymousToPage("/Appointments/Details");
                o.Conventions.AllowAnonymousToPage("/Appointments/Edit");
                o.Conventions.AllowAnonymousToPage("/Appointments/Delete");
                o.Conventions.AllowAnonymousToPage("/Patients/Index");
                o.Conventions.AllowAnonymousToPage("/Patients/Create");
                o.Conventions.AllowAnonymousToPage("/Patients/Details");
                o.Conventions.AllowAnonymousToPage("/Patients/Edit");
                o.Conventions.AllowAnonymousToPage("/Patients/Delete");
                o.Conventions.AllowAnonymousToPage("/Countries/Create");
                o.Conventions.AllowAnonymousToPage("/Countries/Edit");
                o.Conventions.AllowAnonymousToPage("/Countries/Delete");
                o.Conventions.AllowAnonymousToPage("/Currencies/Create");
                o.Conventions.AllowAnonymousToPage("/Currencies/Edit");
                o.Conventions.AllowAnonymousToPage("/Currencies/Delete");
            });
            var sp = s.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            foreach (var type in types) ensureCreated(scopedServices, type);
        }

        private static void ensureCreated(IServiceProvider s, Type t) {
            if (s?.GetRequiredService(t) is not DbContext c)
                throw new ApplicationException($"DBContext {t} not found");
            c?.Database?.EnsureCreated();
            if (!(c?.Database?.IsInMemory() ?? false))
                throw new ApplicationException($"DBContext {t} is not in memory");
        }
        private static void addDb<T>(IServiceCollection s) where T : DbContext 
            => s?.AddDbContext<T>(o => {
            o.UseInMemoryDatabase("Tests"); });
        private static void removeDb<T>(IServiceCollection s) where T : DbContext {
            var descriptor = s?.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
            if (descriptor is not null) { s?.Remove(descriptor); }
        }
    }
}
