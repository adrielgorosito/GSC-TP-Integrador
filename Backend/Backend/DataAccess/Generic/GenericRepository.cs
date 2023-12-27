using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace Backend.DataAccess.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected LoanDbContext context;
        protected DbSet<T> DbSet;

        public GenericRepository(LoanDbContext context)
        {
            this.context = context;
            this.DbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetOne(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>?> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> Add(T t)
        {
            await DbSet.AddAsync(t);
            await context.SaveChangesAsync();

            return (int) context.Entry(t).Property("Id").CurrentValue!;
        }

        public virtual async Task Update(T t)
        {
            context.ChangeTracker.Clear();
            context.Update(t);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(T t)
        {
            context.Remove(t);
            await context.SaveChangesAsync();
        }
    }
}
