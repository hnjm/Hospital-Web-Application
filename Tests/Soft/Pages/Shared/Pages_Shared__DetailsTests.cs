using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.Shared {
    [TestClass] public class Pages_Shared__DetailsTests : SharedCRUDTests {
        [TestMethod] public async Task SharedDetailsTest()
            => await CheckIfContains($"/Appointments/Details?handler=Details&id={id}&order=&idx=0&filter=");
    }
}
