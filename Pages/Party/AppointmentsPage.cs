using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.AspNetCore.Authorization;

namespace EMEHospitalWebApp.Pages.Party {
    [Authorize]
    public class AppointmentsPage : PagedPage<AppointmentView, Appointment, IAppointmentRepo> {
        private readonly IPatientRepo patients;
        public AppointmentsPage(IAppointmentRepo r) : base(r) { }
        protected override Appointment ToObject(AppointmentView? item) => new AppointmentViewFactory().Create(item);
        protected override AppointmentView ToView(Appointment? entity) => new AppointmentViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = {
            nameof(AppointmentView.PatientsId),
            nameof(AppointmentView.DoctorsId),
            nameof(AppointmentView.DateTime),
            nameof(AppointmentView.DiagnosisId)
        };
    }
}
