using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class SealedClassTests<TClass> : BaseTests where TClass : class, new() {
    protected override object CreateObj() => new TClass();
    [TestMethod] public void IsSealedClass() => IsTrue(Obj?.GetType()?.IsSealed ?? false);
}