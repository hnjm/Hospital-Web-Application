using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Infra;
using EMEHospitalWebApp.Infra.Initializers;
using EMEHospitalWebApp.Infra.Party;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddDbContext<HospitalWebAppDb>(o => o.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(o => o.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages(o => {
    o.Conventions.AuthorizePage("/Countries/Create");
    o.Conventions.AuthorizePage("/Countries/Edit");
    o.Conventions.AuthorizePage("/Countries/Delete");
    o.Conventions.AuthorizePage("/Currencies/Create");
    o.Conventions.AuthorizePage("/Currencies/Edit");
    o.Conventions.AuthorizePage("/Currencies/Delete");
});
builder.Services.AddTransient<IAppointmentRepo, AppointmentsRepo>();
builder.Services.AddTransient<IPatientRepo, PatientsRepo>();
builder.Services.AddTransient<ICountriesRepo, CountriesRepo>();
builder.Services.AddTransient<ICurrenciesRepo, CurrenciesRepo>();
builder.Services.AddTransient<ICountryCurrencyRepo, CountryCurrenciesRepo>();
builder.Services.AddTransient<IPatientAppointmentRepo, PatientAppointmentsRepo>();

var app = builder.Build();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope()) {
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<HospitalWebAppDb>();
    _ = (db?.Database?.EnsureCreated());
    HospitalDbInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
