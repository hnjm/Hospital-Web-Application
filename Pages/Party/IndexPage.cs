using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EMEHospitalWebApp.Pages.Party {
    public class IndexPage : PageModel {
        private readonly ILogger<IndexPage> _logger;
        public IndexPage(ILogger<IndexPage> logger) => _logger = logger;
        public void OnGet() { }
    }
}
