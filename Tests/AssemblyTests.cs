using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using EMEHospitalWebApp.Aids;

namespace EMEHospitalWebApp.Tests {
    public abstract class AssemblyTests : TestAsserts {
        private static string testsStr => "Tests";
        private static string testProjectStr => $"{testsStr}.";
        private string notTestedMessage => $"Class \"{fullNameOfFirstNotTested()}\" is not tested";
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string?  namespaceOfTest;
        private string? namespaceOfType;
        [TestMethod] public void IsAllTested() => isAllTested();
        protected virtual void isAllTested() {
            testingAssembly = getAssembly(this);
            testingTypes = getTypes(testingAssembly);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            removeNotInNamespace(testingTypes, namespaceOfTest);
            removeNotInClassTests();
            if (namespaceOfTest is not null and not ("EMEHospitalWebApp.Tests.Soft" or "EMEHospitalWebApp.Tests.Pages")) removeNotInCorrectTests();
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            if (namespaceOfType == "EMEHospitalWebApp.Soft") namespaceOfType = "EMEHospitalWebApp.Pages";
            removeNotInNamespace(typesToBeTested, namespaceOfType);
            removeInterfaces();
            removeNotNeedTesting();
            removeDuplications();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void removeInterfaces() => typesToBeTested?.RemoveAll(t => t.IsInterface);
        private void removeNotInNamespace(List<Type>? t, string? nameSpace) => t?.Remove(x 
            => ! x.NameStarts(nameSpace));
        private void removeNotInClassTests() => testingTypes.Remove(x => !x.NameEnds(testsStr));
        private void removeNotInCorrectTests() => testingTypes.Remove(x => !isCorrectTest(x));
        private static string? removeTestsTagFrom(string? s) => s?.Remove(testProjectStr);
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive(notTestedMessage);
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool allAreTested() => typesToBeTested.IsEmpty();
        private void removeTested() => typesToBeTested?.Remove(isItTested);
        private void removeDuplications() => typesToBeTested?.Find(isItDuplicated);
        private bool isItDuplicated(Type x) {
            var t = typesToBeTested?.Find(y => isDuplicated(y, x));
            if (t is null) return false;
            _ = typesToBeTested?.Remove(t);
            return true;
        }
        private bool isItTested(Type x) {
            var t = testingTypes?.Find(y => isTestFor(y, x));
            if (t is null) return false;
            _ = testingTypes?.Remove(t);
            return true;
        }
        private static bool isCorrectTest(Type x) => isCorrectlyInherited(x) && isTestClass(x);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(TypeTests));
        private static bool isTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.FullName ?? string.Empty;
            testName = testName.RemoveHead();
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            testName += testsStr;
            return testingType.NameEnds($".{testName}");
        }
        private static bool isDuplicated(Type x, Type y) {
            if (x == y) return false;
            var nameX = x.Name;
            var nameY = y.Name;
            var lengthX = nameX.IndexOf('`');
            var lengthY = nameY.IndexOf('`');
            if (lengthX >= 0) nameX = nameX[..lengthX];
            if (lengthY >= 0) nameY = nameY[..lengthY];
            return nameX == nameY;
        }
        private void removeNotNeedTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}
