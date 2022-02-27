using EMEHospitalWebApp.Data;

namespace EMEHospitalWebApp.Domain
{
    public abstract class Entity { }
    public abstract class Entity<TData> : Entity where TData : EntityData, new()
    {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
    }
}
