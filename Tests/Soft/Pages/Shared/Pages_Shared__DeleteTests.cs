using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__DeleteTests : SharedCRUDTests {
        [TestMethod] public async Task SharedDeleteTest()
            => await CheckIfContains($"/Appointments/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
