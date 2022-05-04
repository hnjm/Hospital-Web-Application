namespace EMEHospitalWebApp.Domain
{
    public interface IRepo<T> : IPagedRepo<T> where T : UniqueEntity { }
    public interface IPagedRepo<T> : IOrderedRepo<T> where T : UniqueEntity {
        public int PageIndex { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; }
    }
    public interface IOrderedRepo<T> : IFilteredRepo<T> where T : UniqueEntity {
        public string? CurrentOrder { get; set; }
        public string SortOrder(string propertyName);
    }
    public interface IFilteredRepo<T> : ICrudRepo<T> where T : UniqueEntity {
        public string? CurrentFilter { get; set; }
    }
    public interface ICrudRepo<T> : IBaseRepo<T> where T : UniqueEntity { }
    public interface IBaseRepo<T> where T: UniqueEntity {
        bool Add(T obj);
        List<T> Get();
        List<T> GetAll(Func<T, dynamic>? orderBy = null);
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
