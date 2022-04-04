using System.ComponentModel.DataAnnotations;

namespace EMEHospitalWebApp.Facade;

public abstract class NamedView : UniqueView {
    [Display(Name = "Code")][Required] public string? Code { get; set; }
    [Display(Name = "Name")][Required] public string? Name { get; set; }
    [Display(Name = "Description")] public string? Description { get; set; }
}