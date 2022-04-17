using System.ComponentModel;
using System.Reflection;

namespace EMEHospitalWebApp.Aids {
    public static class Enums {
        public static string Description(this Enum v) {
            var i = v.GetType().GetField(v.ToString());
            var a = i?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return a?.Description ?? v.ToString();
        }
    }
}
