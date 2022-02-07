using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Data.Party;

namespace EMEHospitalWebApp.Facade.Party
{
    public class PatientViewFactory
    {
        public Patient Create(PatientView v)
        {
            var d = new PatientData
            {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                Gender = v.Gender,
                BirthDate = v.BirthDate,
                IdCode = v.IdCode
            };
            return new Patient(d);
        }

        public PatientView Create(Patient o)
        {
            var v = new PatientView
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Gender = o.Gender,
                BirthDate = o.BirthDate,
                IdCode = o.IdCode,
                FullName = o.ToString()
            };
            return v;
        }
    }
}
