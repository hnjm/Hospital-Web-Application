using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_CreateTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
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
        }
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/Patients/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
