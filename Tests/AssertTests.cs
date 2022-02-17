using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class AssertTests
{
    protected void Inconclusive() => Assert.Inconclusive();
    protected static void IsNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
    protected static void AreEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
}