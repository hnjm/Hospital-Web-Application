using System.Diagnostics;
using System.Reflection;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests;

public abstract class BaseTests<TClass>: AssertTests where TClass : class, new()
{
    protected TClass obj;
    protected BaseTests() => obj = new TClass();
    protected void isProperty<T>(T? value = default, bool isReadOnly = false)
    {
        var memberName = getCallingMember(nameof(isProperty)).Replace("Test", string.Empty);
        var propertyInfo = obj.GetType().GetProperty(memberName);
        IsNotNull(propertyInfo);
        if (isNullOrDefault(value)) value = random<T>();
        if (canWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
        AreEqual(value, propertyInfo.GetValue(obj));
    }
    private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
    private static bool canWrite(PropertyInfo i, bool isReadOnly)
    {
        var canWrite = i?.CanWrite?? false;
        AreEqual(canWrite, !isReadOnly);
        return canWrite;
    }
    private static T random<T>() => GetRandom.Value<T>();
    private string getCallingMember(string memberName)
    {
        var s = new StackTrace();
        var isNext = false;
        for (int i = 0; i < s.FrameCount-1; i++)
        {
            var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
            if (n is "MoveNext" or "Start") continue;
            if (isNext) return n;
            if (n == memberName) isNext = true;
        }
        return string.Empty;
    }
}