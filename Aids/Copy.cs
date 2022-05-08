using System.Reflection;

namespace EMEHospitalWebApp.Aids {
    public static class Copy {
        public static void Properties(object? from, object? to) {
            var tFrom = from?.GetType();
            var tTo = to?.GetType();
            foreach (var piFrom in tFrom?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                var v = piFrom.GetValue(from, null);
                var piTo = tTo?.GetProperty(piFrom.Name);
                piTo?.SetValue(to, v, null);
            }
        }
    }
}
