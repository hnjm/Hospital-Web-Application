using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Domain {
    public abstract class NamedEntity<TData> : UniqueEntity<TData> where TData : NamedData, new() {
        protected NamedEntity() : this(new TData()) { }
        protected NamedEntity(TData d) : base(d) { }
        public string Name => getValue(Data?.Name);
        public string Code => getValue(Data?.Code);
        public string Description => getValue(Data?.Description);
    }
}
