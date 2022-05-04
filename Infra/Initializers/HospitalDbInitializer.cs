namespace EMEHospitalWebApp.Infra.Initializers;

public static class HospitalDbInitializer {
    public static void Init(HospitalWebAppDb? db) {
        new AppointmentsInitializer(db).Init();
        new PatientsInitializer(db).Init();
        new CountriesInitializer(db).Init();
        new CurrenciesInitializer(db).Init();
        new CountryCurrenciesInitializer(db).Init();
    }
}
