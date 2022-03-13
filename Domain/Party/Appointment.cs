using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface IAppointmentRepo : IRepo<Appointment> { }
    public class Appointment : Entity<AppointmentData> {
        public Appointment() : this(new AppointmentData()) { }
        public Appointment(AppointmentData d): base(d) { }
        public string PatientsId => getValue(Data?.PatientsId);
        public string DoctorsId => getValue(Data?.DoctorsId);
        public DateTime DateTime => getValue(Data?.DateTime);
        public string DiagnosisId => getValue(Data?.DiagnosisId);
    }
}
