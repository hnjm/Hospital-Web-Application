using System.Reflection;
namespace EMEHospitalWebApp.Aids;

public static class GetAssembly {
    public static Assembly? ByName(string? name) => Safe.Run(() => Assembly.Load(name ?? string.Empty));
    public static Assembly? OfType(object obj) => Safe.Run(() => obj.GetType().Assembly);
    public static List<Type>? Types(Assembly? a) => Safe.Run(() => a?.GetTypes()?.ToList(), new());
    public static Type? Type(this Assembly? a, string? name)
        => Safe.Run(() => a?.DefinedTypes?.FirstOrDefault(x => x.Name == name));
}
