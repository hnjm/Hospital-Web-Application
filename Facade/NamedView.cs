using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Facade {
    public abstract class NamedView : UniqueView {
        [DisplayName("Code")][Required] public string? Code { get; set; }
        [DisplayName("Name")][Required] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
    }
}
