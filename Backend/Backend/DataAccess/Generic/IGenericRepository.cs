namespace Backend.DataAccess.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T?> GetOne(int id);
        public Task<List<T>?> GetAll();
        public Task<int> Add(T t);
        public Task Update(T t);
        public Task Delete(T t);
    }
}
