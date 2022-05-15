using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__CreateTests : SharedCRUDTests {
        [TestMethod] public async Task SharedCreateTest() 
            => await CheckIfContains($"/Appointments/Create?handler=Create&id={id}&order=&idx=0&filter=");
    }
}
