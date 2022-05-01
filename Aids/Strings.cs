namespace EMEHospitalWebApp.Aids;

public static class Strings {
    public static string? Remove(this string? fromString, string theString)
        => Safe.Run(() => fromString?.Replace(theString, String.Empty), String.Empty);
    public static bool IsTypeName(this string? s)
        => Safe.Run(() => s?.All(x => x.IsNameChar()) ?? false);
    public static bool IsTypeFullName(this string? s)
        => Safe.Run(() => s?.All(x => x.IsFullNameChar()) ?? false);
    public static string RemoveTail(this string? s, char separator = '.') {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        for (var i = s.Length; i > 0; i--) {
            var c = s[i - 1];
            s = s[..(i - 1)];
            if (c == separator) return s;
        }
        return s;
    }
    public static string RemoveHead(this string? s, char separator = '.') {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        for (var i = 0; i < s.Length;) {
            var c = s[0];
            s = s[1..];
            if (c == separator) return s;
        }
        return s;
    }
}
