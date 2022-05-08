using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EMEHospitalWebApp.Pages.Party {
    public class PrivaciesPage : PageModel {
        private readonly ILogger<PrivaciesPage> _logger;
        public PrivaciesPage(ILogger<PrivaciesPage> logger) => _logger = logger;
        public void OnGet() { }
    }
}
