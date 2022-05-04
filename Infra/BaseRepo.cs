using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra {
    public abstract class BaseRepo<TDomain, TData> : IBaseRepo<TDomain>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected internal DbContext? db { get; }
        protected internal DbSet<TData>? set { get; }
        protected BaseRepo(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        internal void clear() {
            set?.RemoveRange(set);
            db?.SaveChanges();
        }
        public abstract bool Add(TDomain obj);
        public abstract Task<bool> AddAsync(TDomain obj);
        public abstract bool Delete(string id);
        public abstract Task<bool> DeleteAsync(string id);
        public abstract List<TDomain> Get();
        public abstract List<TDomain> GetAll(Func<TDomain, dynamic>? orderBy = null);
        public abstract TDomain Get(string id);
        public abstract Task<List<TDomain>> GetAsync();
        public abstract Task<TDomain> GetAsync(string id);
        public abstract bool Update(TDomain obj);
        public abstract Task<bool> UpdateAsync(TDomain obj);

    }
}
