using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Facade {
    public abstract class IsoNamedView : NamedView {
        [DisplayName("ISO three-letter code")][Required] public new string? Code { get; set; }
        [DisplayName("English name")] public new string? Name { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }
}
