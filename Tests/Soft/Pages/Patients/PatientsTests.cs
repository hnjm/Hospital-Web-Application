using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class PatientsTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
        private async Task CheckIfContains(string url, string? format = null) {
            var html = await getHtmlPage(url);
            var gender = string.Empty;
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Gender);
            isNotNull(d.IdCode);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
            foreach (var genderValue in genderDictionary.Keys) if (genderValue == d.Gender.Value.ToString()) gender = genderDictionary[genderValue];
            if (!url.Contains("Create") && !url.Contains("Index")) {
                isTrue(html.Contains(d.Id));
                isTrue(html.Contains(d.FirstName));
                isTrue(html.Contains(d.LastName));
                isTrue(html.Contains(gender));
                isTrue(html.Contains(d.BirthDate.Value.ToString(format)));
                //isTrue(html.Contains(d.CountryId)); TODO
            }
        }
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/Patients?handler=Index");
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Patients/Create?handler=Create&id={id}&order=&idx=0&filter=");
        [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/Patients/Details?handler=Details&id={id}&order=&idx=0&filter=", "dd.MM.yyyy HH:mm:ss");
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/Patients/Edit?handler=Edit&id={id}&order=&idx=0&filter=", "yyyy-MM-ddTHH:mm:ss.fff");
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/Patients/Delete?handler=Delete&id={id}&order=&idx=0&filter=", "dd.MM.yyyy HH:mm:ss");
    }
}
