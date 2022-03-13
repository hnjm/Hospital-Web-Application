using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Domain
{
    public abstract class Entity {
        private const string DefaultSrt = "Undefined";
        private static DateTime defaultDate = DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultSrt;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
    }
    public abstract class Entity<TData> : Entity where TData : EntityData, new() {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}
