namespace Backend.DataAccess.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        public T? GetOne(int id);
        public List<T> GetAll();
        public T Add(T t);
        public T Update(T t);
        public void Delete(int id);
    }
}
