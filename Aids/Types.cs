using System.Reflection;

namespace EMEHospitalWebApp.Aids;

public static class Types {
    private static readonly BindingFlags allDeclaredOnly =
        BindingFlags.DeclaredOnly
        | BindingFlags.Public
        | BindingFlags.Instance
        | BindingFlags.Static;
    public static bool BelongsTo(this Type? t, string? namespaceName)
        => (t is not null) && t.IsRealType() && t.NameStarts(namespaceName);
    public static bool NameEnds(this Type? t, string? name)
        => Safe.Run(() => name is not null && (t?.FullName?.EndsWith(name) ?? false));
    public static bool NameStarts(this Type? t, string? name)
        => Safe.Run(() => name is not null && (t?.FullName?.StartsWith(name) ?? false));
    public static bool IsRealType(this Type? t)
        => Safe.Run(() => t?.FullName?.IsTypeFullName() ?? false);
    public static string? GetName(Type? t) => t?.Name ?? string.Empty;
    public static List<string>? DeclaredMembers(this Type? t)
        => t?.GetMembers(allDeclaredOnly)?.ToList()?.Select(x => x.Name)?.ToList() ?? new();
    public static bool IsInherited(this Type? t, Type subclass)
        => Safe.Run(() => t?.IsSubclassOf(subclass) ?? false, false);
    public static bool HasAttribute<TAttribute>(this Type? t) where TAttribute : Attribute
        => Safe.Run(() => t?.GetCustomAttributes<TAttribute>()?.FirstOrDefault() is not null, false);
    public static MethodInfo? Method(this Type? t, string methodName) => Safe.Run(() => t?.GetMethod(methodName));
}
