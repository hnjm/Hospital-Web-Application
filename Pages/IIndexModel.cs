using EMEHospitalWebApp.Facade;

namespace EMEHospitalWebApp.Pages;

public interface IIndexModel<TView> where TView : UniqueView {
    public string[] IndexColumns { get; }
    public IList<TView>? Items { get; }
    public object? GetValue(string name, TView v);
    public string? DisplayName(string name);
}
