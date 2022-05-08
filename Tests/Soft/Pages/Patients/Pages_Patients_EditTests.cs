using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class Pages_Patients_EditTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
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
            isTrue(html.Contains(d.Id));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(gender));
            isTrue(html.Contains(d.BirthDate.Value.ToString(format)));
            //isTrue(html.Contains(d.CountryId)); TODO
        }
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/Patients/Edit?handler=Edit&id={id}&order=&idx=0&filter=", "yyyy-MM-ddTHH:mm:ss.fff");
    }
}
