using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Infra.Initializers {
    public sealed class AppointmentsInitializer : BaseInitializer<AppointmentData> {
        public AppointmentsInitializer(HospitalWebAppDb? db) : base(db, db?.Appointments) {}
        protected override IEnumerable<AppointmentData> getEntities => new [] {
            createAppointment("1214515", "M.Herem", "K.Laanet", DateTime.Parse("2022-1-25 14:12:18"), "#224225"),
            createAppointment("1251251", "H.Haugas", "K.Jürgenson", DateTime.Parse("2022-1-29 12:05:33"), "#224442")
        };
        internal AppointmentData createAppointment(string Id, string PatientsId, string DoctorsId, DateTime DateTime, string DiagnosisId) {
            var Appointment = new AppointmentData {
                Id = Id,
                PatientsId = PatientsId,
                DoctorsId = DoctorsId,
                DateTime = DateTime,
                DiagnosisId = DiagnosisId
            };
            return Appointment;
        }
    }
}
