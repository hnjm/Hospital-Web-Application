using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class TestAsserts {
    protected static void IsInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
    protected static void IsNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
    protected static void AreEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
}
