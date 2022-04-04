using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Facade;

public abstract class IsoNamedView : NamedView {
    [Display(Name = "ISO three-letter code")][Required] public new string? Code { get; set; }
    [Display(Name = "English name")][Required] public new string? Name { get; set; }
    [Display(Name = "Native name")] public new string? Description { get; set; }
}