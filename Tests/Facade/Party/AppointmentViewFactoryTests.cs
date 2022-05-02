using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Facade.Party {
    [TestClass] public class AppointmentViewFactoryTests : 
        ViewFactoryTests<AppointmentViewFactory, AppointmentView, Appointment, AppointmentData> {
        protected override Appointment toObject(AppointmentData d) => new(d);
    }
}
