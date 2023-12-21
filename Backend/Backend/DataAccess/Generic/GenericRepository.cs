using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private LoanDbContext context;
        private DbSet<T> dbSet;

        public GenericRepository(LoanDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T? GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }


        public T Add(T t)
        {
            throw new NotImplementedException();
        }

        
        public T Update(T t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
