using System;
using System.Linq;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        private Type type = typeof(object);
        private string? nameSpace;
        private string? fullName;
        private string? name;
        private string? randomStr;
        [TestInitialize] public void Init() {
            type = typeof(CountryData);
            nameSpace = type.Namespace;
            fullName = type.FullName;
            name = type.Name;
            randomStr = GetRandom.String();
        }
        [TestMethod] public void BelongsToTest() {
            IsTrue(type.BelongsTo(nameSpace));
            IsFalse(type.BelongsTo(randomStr));
        }
        [TestMethod] public void NameIsTest() {
            IsTrue(type.BelongsTo(fullName));
            IsFalse(type.BelongsTo(randomStr));
        }
        [TestMethod] public void NameEndsTest() {
            IsTrue(type.NameEnds(name));
            IsFalse(type.NameEnds(randomStr));
        }
        [TestMethod] public void NameStartsTest() {
            IsTrue(type.NameStarts(nameSpace));
            IsFalse(type.NameStarts(randomStr));
        }
        [TestMethod] public void IsRealTypeTest() {
            IsTrue(type.IsRealType());
            IsTrue(typeof(NamedData).IsRealType());
            var a = GetAssembly.OfType(this);
            var allTypes = (a?.GetTypes() ?? Array.Empty<Type>()).ToList();
            var realTypes = allTypes?.FindAll(t => t.IsRealType());
            IsNotNull(realTypes);
            IsTrue(realTypes.Count < (allTypes?.Count ?? 0));
            IsTrue(realTypes.Count > 0);
        }
        [TestMethod] public void GetNameTest() {
            AreEqual(name, Types.GetName(type));
            AreNotEqual(randomStr, Types.GetName(type));
        }
        [TestMethod] public void DeclaredMembersTest() {
            AreEqual(1, type.DeclaredMembers()?.Count);
            var l = typeof(NamedData)?.DeclaredMembers();
            AreEqual(9, l?.Count);
        }
        [TestMethod] public void IsInheritedTest() {
            Type? nullType = null;
            IsTrue(type.IsInherited(typeof(object)));
            IsTrue(type.IsInherited(typeof(NamedData)));
            IsFalse(type.IsInherited(nullType));
            IsFalse(type.IsInherited(typeof(CurrencyData)));
        }
        [TestMethod] public void HasAttributeTest() {
            IsFalse(type.HasAttribute<TestClassAttribute>());
            IsTrue(GetType().HasAttribute<TestClassAttribute>());
            IsFalse(type.HasAttribute<TestMethodAttribute>());
            IsFalse(GetType().HasAttribute<TestMethodAttribute>());
        }
        [TestMethod] public void MethodTest() {
            var n = nameof(MethodTest);
            var m = GetType().Method(n);
            AreEqual(n, m?.Name);
        }
    }
}
