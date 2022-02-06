using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Domain.Party
{
    public class Patient 
    {
        private const string defaultSrt = "Undefined";
        private DateTime defaultDate = DateTime.MinValue;

        private PatientData data;

        public Patient() : this(new PatientData()) { }
        public Patient (PatientData d) => data = d;

        public string Id => data?.Id?? defaultSrt;
        public string FirstName => data?.FirstName ?? defaultSrt;
        public string LastName => data?.LastName ?? defaultSrt;
        public string Gender => data?.Gender ?? defaultSrt; 
        public DateTime BirthDate => data?.BirthDate ?? defaultDate;   
        public string IdCode => data?.IdCode ?? defaultSrt;

        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {BirthDate})";

        public PatientData Data => data;




    }
}
