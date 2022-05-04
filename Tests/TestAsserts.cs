using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests {
    public abstract class TestAsserts {
        protected static void isTrue(bool? b, string? msg = null) => Assert.IsTrue(b ?? false, msg ?? string.Empty);
        protected static void isFalse(bool? b, string? msg = null) => Assert.IsFalse(b ?? true, msg ?? string.Empty);
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null, string? msg = null) => Assert.IsNotNull(o, msg);
        protected static void isNull(object? o = null, string? msg = null) => Assert.IsNull(o, msg);
        protected static void areEqual(object? expected, object? actual, string? msg = null) => Assert.AreEqual(expected, actual, msg);
        protected static void areNotEqual(object? expected, object? actual, string? msg = null) => Assert.AreNotEqual(expected, actual, msg);
        protected static void isInstanceOfType(object o, Type expectedType, string? msg = null) => Assert.IsInstanceOfType(o, expectedType, msg);
        protected virtual void areEqualProperties(object? a, object? b, params string[] exclude) {
            isNotNull(a);
            isNotNull(b);
            var tA = a?.GetType();
            var tB = b?.GetType();
            foreach (var piA in tA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                if (exclude?.Contains(piA.Name) ?? false) continue;
                var vA = piA.GetValue(a, null);
                var piB = tB?.GetProperty(piA.Name);
                var vB = piB?.GetValue(b, null);
                areEqual(vA, vB, $"For property {piA.Name}.");
            }
        }
    }
}
