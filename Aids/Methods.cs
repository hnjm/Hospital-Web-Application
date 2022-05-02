using System.Reflection;

namespace EMEHospitalWebApp.Aids;

public static class Methods {
    public static bool HasAttribute<TAttribute>(this MemberInfo? m) where TAttribute : Attribute
        => m?.GetAttribute<TAttribute>() is not null;
    public static TAttribute? GetAttribute<TAttribute>(this MemberInfo? m) where TAttribute : Attribute
        => Safe.Run(() => m?.GetCustomAttributes<TAttribute>()?.FirstOrDefault());
}
