using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface IAppointmentRepo : IRepo<Appointment> { }
    public sealed class Appointment : UniqueEntity<AppointmentData> {
        public Appointment() : this(new AppointmentData()) { }
        public Appointment(AppointmentData d): base(d) { }
        public string PatientsId => getValue(Data?.PatientsId);
        public string DoctorsId => getValue(Data?.DoctorsId);
        public DateTime DateTime => getValue(Data?.DateTime);
        public string DiagnosisId => getValue(Data?.DiagnosisId);
        public override string ToString() => $"{PatientsId} {DoctorsId} {DateTime} {DiagnosisId}";
        public List<PatientAppointment> PatientAppointments
            => GetRepo.Instance<IPatientAppointmentRepo>()?
                .GetAll(x => x.PatientId)?
                .Where(x => x.PatientId == Id)?
                .ToList() ?? new List<PatientAppointment>();
        public List<Patient?> Patients
            => PatientAppointments
                .Select(x => x.Patient)
                .ToList() ?? new List<Patient?>();
    }
}
