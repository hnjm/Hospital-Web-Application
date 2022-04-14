using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMEHospitalWebApp.Infra {
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData> 
        where TDomain : UniqueEntity<TData>, new() where TData: UniqueData, new() {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s){}
        protected internal static bool contains(string? value, string? s) => (s is null) || (value?.Contains(s) ?? false);
    };
}
