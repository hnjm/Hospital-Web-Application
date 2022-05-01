using System;
using System.Linq;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class TypesTests : TypeTests {
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
            isTrue(type.BelongsTo(nameSpace));
            isFalse(type.BelongsTo(randomStr));
        }
        [TestMethod] public void NameIsTest() {
            isTrue(type.BelongsTo(fullName));
            isFalse(type.BelongsTo(randomStr));
        }
        [TestMethod] public void NameEndsTest() {
            isTrue(type.NameEnds(name));
            isFalse(type.NameEnds(randomStr));
        }
        [TestMethod] public void NameStartsTest() {
            isTrue(type.NameStarts(nameSpace));
            isFalse(type.NameStarts(randomStr));
        }
        [TestMethod] public void IsRealTypeTest() {
            isTrue(type.IsRealType());
            isTrue(typeof(NamedData).IsRealType());
            var a = GetAssembly.OfType(this);
            var allTypes = (a?.GetTypes() ?? Array.Empty<Type>()).ToList();
            var realTypes = allTypes?.FindAll(t => t.IsRealType());
            isNotNull(realTypes);
            isTrue(realTypes.Count < (allTypes?.Count ?? 0));
            isTrue(realTypes.Count > 0);
        }
        [TestMethod] public void GetNameTest() {
            areEqual(name, Types.GetName(type));
            areNotEqual(randomStr, Types.GetName(type));
        }
        [TestMethod] public void DeclaredMembersTest() {
            areEqual(1, type.DeclaredMembers()?.Count);
            var l = typeof(NamedData)?.DeclaredMembers();
            areEqual(9, l?.Count);
        }
        [TestMethod] public void IsInheritedTest() {
            Type? nullType = null;
            isTrue(type.IsInherited(typeof(object)));
            isTrue(type.IsInherited(typeof(NamedData)));
            isFalse(type.IsInherited(nullType));
            isFalse(type.IsInherited(typeof(CurrencyData)));
        }
        [TestMethod] public void HasAttributeTest() {
            isFalse(type.HasAttribute<TestClassAttribute>());
            isTrue(GetType().HasAttribute<TestClassAttribute>());
            isFalse(type.HasAttribute<TestMethodAttribute>());
            isFalse(GetType().HasAttribute<TestMethodAttribute>());
        }
        [TestMethod] public void MethodTest() {
            var n = nameof(MethodTest);
            var m = GetType().Method(n);
            areEqual(n, m?.Name);
        }
    }
}
