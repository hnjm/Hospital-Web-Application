namespace EMEHospitalWebApp.Aids;

public static class GetRandom {
    public static int Int32(int min = int.MinValue, int max = int.MaxValue) 
        => Random.Shared.Next(min, max);
    public static double Double(double min = short.MinValue, double max = short.MaxValue) 
        => min + Random.Shared.NextDouble() * (max - min);
    public static char Char(char min = char.MinValue, char max = char.MaxValue) 
        => (char) Int32(min, max);
    public static bool Bool() => Int32() % 2 == 0;
    public static DateTime DateTime(ushort minYear = 1900, ushort maxYear = 2100) {
        var year = Int32(minYear, maxYear - 1);
        var day = Int32(1, 364);
        var seconds = Int32(1, 24 * 60 * 60);
        var d = new DateTime(year);
        d = d.AddDays(day);
        d = d.AddSeconds(seconds);
        return d;
    }
    public static string String(ushort minLength = 5, ushort maxLength = 30) {
        var s = string.Empty;
        var length = Int32(minLength, maxLength);
        for (var i = 0; i < length; i++) s += Char('a', 'z');
        return s;
    }
    public static dynamic Value<T>() {
        if (typeof(T) == typeof(bool)) return Bool();
        if (typeof(T) == typeof(bool?)) return Bool();
        if (typeof(T) == typeof(DateTime)) return DateTime();
        if (typeof(T) == typeof(DateTime?)) return DateTime();
        return String();
    }
}