using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party
{
    public class Appointment : Entity<AppointmentData> {
        private const string DefaultSrt = "Undefined";
        private DateTime _defaultDate = DateTime.MinValue;
        public Appointment() : this(new AppointmentData()) { }
        public Appointment(AppointmentData d): base(d) { }
        public string Id => Data?.Id ?? DefaultSrt;
        public string PatientsId => Data?.PatientsId ?? DefaultSrt;
        public string DoctorsId => Data?.DoctorsId ?? DefaultSrt;
        public DateTime DateTime => Data?.DateTime ?? _defaultDate;
        public string DiagnosisId => Data?.DiagnosisId ?? DefaultSrt;
    }
}
