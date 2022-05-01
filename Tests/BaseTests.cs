using EMEHospitalWebApp.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;

namespace EMEHospitalWebApp.Tests {
    public abstract class BaseTests<TClass, TBaseClass> : TypeTests
        where TClass : class where TBaseClass : class {
        protected TClass obj;
        protected BaseTests() => obj = createObj();
        protected abstract TClass createObj();
        protected void isProperty<T>(T? value = default, bool isReadOnly = false, string? callingMethod = null) {
            callingMethod ??= nameof(isProperty);
            var actual = getProperty(ref value, isReadOnly, callingMethod);
            areEqual(value, actual);
        }
        protected object? getProperty<T>(ref T? value, bool isReadOnly, string callingMethod) {
            var memberName = getCallingMember(callingMethod).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            isNotNull(propertyInfo);
            if (!isReadOnly && isNullOrDefault(value)) value = random<T>();
            if (canWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            return propertyInfo.GetValue(obj);
        }
        protected void isReadOnly<T>(T? value) => isProperty(value, true, nameof(isReadOnly));
        protected override object? isReadOnly<T>(string? callingMethod = null) {
            var v = default(T);
            return getProperty<T>(ref v, true, callingMethod ?? nameof(isReadOnly));
        }
        private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool canWrite(PropertyInfo i, bool isReadOnly) {
            var canWrite = i?.CanWrite ?? false;
            areEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T? random<T>() => GetRandom.Value<T>();
        private static string getCallingMember(string memberName) {
            var s = new StackTrace();
            var isNext = false;
            for (var i = 0; i < s.FrameCount - 1; i++) {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }

            return string.Empty;
        }
        protected internal static void arePropertiesEqual(object x, object y) {
            var e = Array.Empty<PropertyInfo>();
            var px = x?.GetType()?.GetProperties() ?? e;
            var hasProperties = false;
            foreach (var p in px) {
                var a = p.GetValue(x, null);
                var py = y?.GetType()?.GetProperty(p.Name);
                if (py is null) continue;
                var b = py?.GetValue(y, null);
                areEqual(a, b);
                hasProperties = true;
            }
            isTrue(hasProperties, $"No properties found for {x}");
        }
        [TestMethod] public void BaseClassTest() => areEqual(typeof(TClass).BaseType, typeof(TBaseClass));
    }
}
