using System.ComponentModel;

namespace EMEHospitalWebApp.Data {
    public enum IsoGender {
        [Description("Not known")] NotKnown = 0,
        [Description("Male")] Male = 1,
        [Description("Female")] Female = 2,
        [Description("Not applicable")] NotApplicable = 9
    }
}
