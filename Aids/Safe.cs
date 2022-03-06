namespace EMEHospitalWebApp.Aids;

public class Safe {
    public static T? Run<T>(Func<T> f, T? defaultResult = default) {
        try { return f(); } catch { return defaultResult; }
    }
    public static void Run(Action a) { try { a(); } catch { } }
}
