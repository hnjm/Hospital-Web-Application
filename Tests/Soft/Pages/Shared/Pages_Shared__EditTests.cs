using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__EditTests : SharedCRUDTests {
        [TestMethod] public async Task SharedEditTest()
            => await CheckIfContains($"/Appointments/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
    }
}
