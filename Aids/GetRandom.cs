using System.Reflection;

namespace EMEHospitalWebApp.Aids;

public static class GetRandom {
    private static void minFirst<T>(ref T min, ref T max) where T : IComparable<T> {
        if (min.CompareTo(max) < 0) return;
        var v = min;
        min = max;
        max = v;
    }
    public static int Int32(int? min = null, int? max = null) {
        var minVal = min ?? -1000;
        var maxVal = max ?? 1000;
        minFirst(ref minVal, ref maxVal);
        return Random.Shared.Next(minVal, maxVal);
    }
    public static long Int64(long? min = null, long? max = null) {
        var minVal = min ?? -1000L;
        var maxVal = max ?? 1000L;
        minFirst(ref minVal, ref maxVal);
        return Random.Shared.NextInt64(minVal, maxVal);
    }
    public static double Double(double? min = null, double? max = null) {
        var minVal = min ?? -1000.0;
        var maxVal = max ?? 1000.0;
        minFirst(ref minVal, ref maxVal);
        return minVal + Random.Shared.NextDouble() * (maxVal - minVal);
    }
    public static char Char(char min = char.MinValue, char max = char.MaxValue) 
        => (char) Int32(min, max);
    public static bool Bool() => Int32() % 2 == 0;
    public static DateTime DateTime(DateTime? min = null, DateTime? max = null) {
        var minVal = (min ?? System.DateTime.MinValue).Ticks;
        var maxVal = (max ?? System.DateTime.MaxValue).Ticks;
        minFirst(ref minVal, ref maxVal);
        var v = Int64(minVal, maxVal);
        return System.DateTime.MinValue.AddTicks(v);
    }
    public static string String(ushort minLength = 5, ushort maxLength = 30) {
        var s = string.Empty;
        var length = Int32(minLength, maxLength);
        for (var i = 0; i < length; i++) s += Char('a', 'z');
        return s;
    }
    public static dynamic? Value<T>(T? min = default, T? max = default) {
        if (typeof(T) == typeof(bool)) return Bool();
        if (typeof(T) == typeof(bool?)) return Bool();
        if (typeof(T) == typeof(DateTime)) return DateTime(Convert.ToDateTime(min), Convert.ToDateTime(max));
        if (typeof(T) == typeof(DateTime?)) return DateTime(Convert.ToDateTime(min), Convert.ToDateTime(max));
        if (typeof(T) == typeof(double)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
        if (typeof(T) == typeof(double?)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
        if (typeof(T) == typeof(long)) return Int64(Convert.ToInt64(min), Convert.ToInt64(max));
        if (typeof(T) == typeof(long?)) return Int64(Convert.ToInt64(min), Convert.ToInt64(max));
        if (typeof(T) == typeof(int)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
        if (typeof(T) == typeof(int?)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
        if (typeof(T) == typeof(char)) return Char(Convert.ToChar(min), Convert.ToChar(max));
        if (typeof(T) == typeof(char?)) return Char(Convert.ToChar(min), Convert.ToChar(max));
        if (typeof(T) == typeof(string)) return String();
        return TryGetObject<T>();
    }

    public static dynamic? Value(Type t) {
        if (t == typeof(bool)) return Bool();
        if (t == typeof(bool?)) return Bool();
        if (t == typeof(DateTime)) return DateTime();
        if (t == typeof(DateTime?)) return DateTime();
        if (t == typeof(double)) return Double();
        if (t == typeof(double?)) return Double();
        if (t == typeof(long)) return Int64();
        if (t == typeof(long?)) return Int64();
        if (t == typeof(int)) return Int32();
        if (t == typeof(int?)) return Int32();
        if (t == typeof(char)) return Char();
        if (t == typeof(char?)) return Char();
        if (t == typeof(string)) return String();
        return null;
    }

    private static T TryGetObject<T>() {
        var o = TryCreate<T>();
        foreach (var pi in o?.GetType()?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
            if (!pi.CanWrite) continue;
            var v = Value(pi.PropertyType);
            pi.SetValue(o, v, null);
        }
        return o;
    }

    private static T TryCreate<T>() {
        var c = typeof(T).GetConstructor(Array.Empty<Type>());
        return (T) c?.Invoke(null);
    }
}
