using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests;

public abstract class SealedClassTests<TClass, TBaseClass> : BaseTests<TClass, TBaseClass> 
    where TClass : class, new() where TBaseClass : class {
    protected override TClass createObj() => new TClass();
    [TestMethod] public void IsSealedClass() => isTrue(obj?.GetType()?.IsSealed ?? false);
}
