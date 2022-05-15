using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__IndexTests : SharedCRUDTests {
        [TestMethod] public async Task LoginTest() {
            var html = await getHtmlPage("/Identity/Account/Login");
            isTrue(html.Contains("Use a local account to log in."));
        }
        //[TestMethod] public async Task LoginTest2() { TODO
        //    var html = await getHtmlPage("/Identity/Account/Manage", clientTest);
        //    //isTrue(html.Contains(""));
        //}
        [TestMethod] public async Task RegisterTest() {
            var html = await getHtmlPage("/Identity/Account/Register");
            isTrue(html.Contains("Create a new account."));
        }
    }
}
