using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;

namespace EMEHospitalWebApp.Pages {
    public class AppointmentsPage : BasePage<AppointmentView, Appointment, IAppointmentRepo> {
        public AppointmentsPage(IAppointmentRepo r) : base(r) { }
        protected override Appointment ToObject(AppointmentView? item) => new AppointmentViewFactory().Create(item);
        protected override AppointmentView ToView(Appointment? entity) => new AppointmentViewFactory().Create(entity);
    }
}
