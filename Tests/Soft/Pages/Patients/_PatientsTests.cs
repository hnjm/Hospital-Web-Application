using System.Linq;
using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Patients {
    [TestClass] public class PatientsTests : PagesTests<IPatientRepo, Patient, PatientData, PatientView> {
        [TestInitialize] public void Init() => Init(x => new Patient(x));
        protected async Task CheckIfContains(string url, string? format = null) {
            var html = await getHtmlPage(url);
            var gender = string.Empty;
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Gender);
            isNotNull(d.IdCode);
            if (displayNameList is not null) foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (genderDictionary?.Keys is not null) foreach (var genderValue in genderDictionary.Keys.Where(genderValue 
                                                                 => genderValue == d.Gender.Value.ToString())) gender = genderDictionary[genderValue];
            if (!url.Contains("Create")) {
                isTrue(html.Contains(d.Id));
                isTrue(html.Contains(d.FirstName));
                isTrue(html.Contains(d.LastName));
                isTrue(html.Contains(gender)); 
                isNotNull(d.BirthDate);
                isTrue(html.Contains(d.BirthDate.Value.ToString(format)));
                //isTrue(html.Contains(d.CountryId)); TODO
            }
        }
    }
}
