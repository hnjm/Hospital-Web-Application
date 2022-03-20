using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class TestAsserts {
    protected static void IsTrue(bool? b, string? msg = null) => Assert.IsTrue(b ?? false, msg ?? string.Empty);
    protected static void IsFalse(bool? b, string? msg = null) => Assert.IsFalse(b ?? true, msg ?? string.Empty);
    protected static void IsInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
    protected static void IsNotNull([NotNull] object? o = null, string? msg = null) => Assert.IsNotNull(o, msg);
    protected static void AreEqual(object? expected, object? actual, string? msg = null) => Assert.AreEqual(expected, actual, msg);
    protected static void AreNotEqual(object? expected, object? actual, string? msg = null) => Assert.AreNotEqual(expected, actual, msg);
    protected static void IsInstanceOfType(object o, Type expectedType, string? msg = null) => Assert.IsInstanceOfType(o, expectedType, msg);
}
