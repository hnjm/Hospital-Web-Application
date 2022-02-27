using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party
{
    public class Patient : Entity<PatientData> {
        private const string DefaultSrt = "Undefined";
        private DateTime _defaultDate = DateTime.MinValue;
        public Patient() : this(new PatientData()) { }
        public Patient(PatientData d) : base(d) { }
        public string Id => Data?.Id?? DefaultSrt;
        public string FirstName => Data?.FirstName ?? DefaultSrt;
        public string LastName => Data?.LastName ?? DefaultSrt;
        public string Gender => Data?.Gender ?? DefaultSrt; 
        public DateTime BirthDate => Data?.BirthDate ?? _defaultDate;   
        public string IdCode => Data?.IdCode ?? DefaultSrt;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {BirthDate})";
    }
}
