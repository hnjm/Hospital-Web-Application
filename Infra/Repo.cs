using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra {
    public abstract class Repo<TDomain, TData> : IRepo<TDomain> 
        where TDomain : Entity<TData>, new() where TData: EntityData, new() {

        private readonly DbContext? db;
        private readonly DbSet<TData>? set;

        protected Repo(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }

        public bool Add(TDomain obj) => AddAsync(obj).GetAwaiter().GetResult();
        public bool Delete(string id) => DeleteAsync(id).GetAwaiter().GetResult();
        public List<TDomain> Get() => GetAsync().GetAwaiter().GetResult();
        public TDomain Get(string id) => GetAsync(id).GetAwaiter().GetResult();
        public bool Update(TDomain obj) => UpdateAsync(obj).GetAwaiter().GetResult();

        public async Task<bool> AddAsync(TDomain obj) {
            var d = obj.Data;
            try {
                _ = (set is null) ? null : await set.AddAsync(d);
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(string id) {
            try {
                var d = (set is null) ? null : await set.FindAsync(id);
                if (d == null) return false;
                _ = set?.Remove(d);
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }
        public async Task<List<TDomain>> GetAsync() {
            try {
                var list = (set is null) ? new List<TData>() : await set.ToListAsync();
                var items = new List<TDomain>();
                foreach (var d in list) items.Add(ToDomain(d));
                return items;
            } catch { return new List<TDomain>(); }
        }
        public async Task<TDomain> GetAsync(string? id) {
            try {
                if (id == null) return new TDomain();
                var d = (set is null) ? null : await set.FirstOrDefaultAsync(x => x.Id == id);
                return d == null ? new TDomain() : ToDomain(d);
            } catch { return new TDomain(); }
        }
        public async Task<bool> UpdateAsync(TDomain obj)
        {
            try {
                var d = obj.Data;
                if (db is not null) db.Attach(d).State = EntityState.Modified;
                _ = (db is null) ? 0 : await db.SaveChangesAsync();
                return true;
            } catch {
                return false;
            }
        }
        protected abstract TDomain ToDomain(TData d);
    };
}
