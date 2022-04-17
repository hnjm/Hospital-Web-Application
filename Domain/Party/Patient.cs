using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party {
    public interface IPatientRepo : IRepo<Patient> { }
    public class Patient : UniqueEntity<PatientData> {
        public Patient() : this(new PatientData()) { }
        public Patient(PatientData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender); 
        public DateTime BirthDate => getValue(Data?.BirthDate);
        public string IdCode => getValue(Data?.IdCode);
        public string CountryId => getValue(Data?.CountryId);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()}, {BirthDate})";
        public Country? Country { get; set; }
    }
}
