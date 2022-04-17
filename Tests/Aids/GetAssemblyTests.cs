using System;
using System.Linq;
using System.Reflection;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Aids {
    [TestClass] public class GetAssemblyTests : IsTypeTested {
        private string? assemblyName;
        private Assembly? assembly;
        private string[] typeNames = Array.Empty<string>();
        [TestInitialize] public void Init() {
            assemblyName = $"{nameof(EMEHospitalWebApp)}.{nameof(EMEHospitalWebApp.Aids)}";
            assembly = GetAssembly.ByName(assemblyName);
            typeNames = new[] { nameof(Chars), nameof(Enums), nameof(Lists),
                nameof(Strings), nameof(Safe), nameof(Types) };
        }
        [TestCleanup] public void Clean() {
            IsNotNull(assembly);
            AreEqual(assemblyName, assembly.GetName().Name);
        }
        [TestMethod] public void ByNameTest() { }
        [TestMethod] public void OfTypeTest() {
            assemblyName = $"{nameof(EMEHospitalWebApp)}.{nameof(EMEHospitalWebApp.Data)}";
            var obj = new CountryData();
            assembly = GetAssembly.OfType(obj);
        }
        [TestMethod] public void TypesTest() {
            var l = GetAssembly.Types(assembly);
            IsTrue(typeNames.Length <= (l?.Count ?? -1));
            foreach(var n in typeNames) 
                AreEqual(l?.FirstOrDefault(x => x.Name == n)?.Name, n);
            IsNull(l?.FirstOrDefault(x => x.Name == GetRandom.String()));
        }
        [TestMethod] public void TypeTest() {
            var n = randomTypeName;
            var obj = GetAssembly.Type(assembly, n);
            IsNotNull(obj);
            AreEqual(n, obj.Name);
        }
        private string randomTypeName => typeNames[GetRandom.Int32(0, typeNames.Length)];
    }
}
