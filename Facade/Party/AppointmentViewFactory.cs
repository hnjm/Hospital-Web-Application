using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;

namespace EMEHospitalWebApp.Facade.Party
{
    public class AppointmentViewFactory
    {
        public Appointment Create(AppointmentView v)
        {
            var d = new AppointmentData
            {
                Id = v.Id,
                PatientsId = v.PatientsId,
                DoctorsId = v.DoctorsId,
                DateTime = v.DateTime,
                DiagnosisId = v.DiagnosisId,
            };
            return new Appointment(d);
        }

        public AppointmentView Create(Appointment o)
        {
            var v = new AppointmentView
            {
                Id = o.Id,
                PatientsId = o.PatientsId,
                DoctorsId = o.DoctorsId,
                DateTime = o.DateTime,
                DiagnosisId = o.DiagnosisId,
            };
            return v;
        }
    }
}
