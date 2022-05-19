using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface IPatientRepo : IRepo<Patient> { }
    public sealed class Patient : UniqueEntity<PatientData> {
        public Patient() : this(new PatientData()) { }
        public Patient(PatientData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender); 
        public DateTime BirthDate => getValue(Data?.BirthDate);
        public string IdCode => getValue(Data?.IdCode);
        public string CountryId => getValue(Data?.CountryId);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()}, {BirthDate}) {Country?.Name}";
        public List<PatientAppointment> PatientAppointments
            => GetRepo.Instance<IPatientAppointmentRepo>()?
                .GetAll(x => x.AppointmentId)?
                .Where(x => x.AppointmentId == Id)?
                .ToList() ?? new List<PatientAppointment>();
        public List<Appointment?> Appointments
            => PatientAppointments
                .Select(x => x.Appointment)
                .ToList() ?? new List<Appointment?>();
        public Country? Country => GetRepo.Instance<ICountriesRepo>()?.Get(CountryId);
    }
}
