namespace EMEHospitalWebApp.Domain
{
    public interface IRepo<T> : IBaseRepo<T> where T : Entity { }

    public interface IBaseRepo<T> where T: Entity {
        bool Add(T obj);
        List<T> Get();
        T Get(string id);
        bool Update(T obj);
        bool Delete(string id);

        Task<bool> AddAsync(T obj);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);
    }
}
