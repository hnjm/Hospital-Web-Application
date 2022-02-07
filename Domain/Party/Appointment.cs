using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party
{
    public class Appointment
    {
        private const string defaultSrt = "Undefined";
        private DateTime defaultDate = DateTime.MinValue;

        private AppointmentData data;

        public Appointment() : this(new AppointmentData()) { }
        public Appointment(AppointmentData d) => data = d;

        public string Id => data?.Id ?? defaultSrt;
        public string PatientsId => data?.PatientsId ?? defaultSrt;
        public string DoctorsId => data?.DoctorsId ?? defaultSrt;
        public DateTime DateTime => data?.DateTime ?? defaultDate;
        public string DiagnosisId => data?.DiagnosisId ?? defaultSrt;

        public AppointmentData Data => data;
    }
}
