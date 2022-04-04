using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Infra.Initializers;

public sealed class PatientsInitializer : BaseInitializer<PatientData> {
    public PatientsInitializer(HospitalWebAppDb? db) : base(db, db?.Patients) {}
    protected override IEnumerable<PatientData> getEntities => new[] {
        createPatient("13642146", "Mihkel", "Herem", DateTime.Parse("1973-12-17 10:15:57"), "Male", "40044028135"),
        createPatient("65123461", "Harri",  "Haugas", DateTime.Parse("2002-10-5 14:18:49"), "Male", "50539245821")
    };
    internal PatientData createPatient(string Id, string FirstName, string LastName, DateTime BirthDate, string Gender, string IdCode) {
        var Patient = new PatientData {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            BirthDate = BirthDate,
            Gender = Gender,
            IdCode = IdCode,
        };
        return Patient;
    }
}
