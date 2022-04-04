using System.Reflection;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;

namespace EMEHospitalWebApp.Facade {
    public abstract class BaseViewFactory<TView, TEntity, TData>
        where TView : class, new()
        where TData : UniqueData, new()
        where TEntity : UniqueEntity<TData>
    {
        protected abstract TEntity ToEntity(TData data);
        protected virtual void Copy(object? from, object? to) {
            var tFrom = from?.GetType();
            var tTo = to?.GetType();
            foreach (var piFrom in tFrom?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                var v = piFrom.GetValue(from, null);
                var piTo = tTo?.GetProperty(piFrom.Name);
                piTo?.SetValue(to, v, null);
            }
        }
        public virtual TEntity Create(TView? v) {
            var d = new TData();
            Copy(v, d);
            return ToEntity(d);
        }
        public virtual TView Create(TEntity? e) {
            var d = e?.Data;
            var v = new TView();
            Copy(d, v);
            return v;
        }
    }
}
