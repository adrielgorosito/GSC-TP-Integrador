using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class PeopleRepository : GenericRepository<Person>
    {
        public PeopleRepository(LoanDbContext context) : base(context) { }

        public override async Task<Person?> GetOne(int dni)
        {
            return await DbSet.FindAsync(dni);
        }

        public override async Task<int> Add(Person person)
        {
            await DbSet.AddAsync(person);
            await context.SaveChangesAsync();

            return await Task.FromResult(0);
        }
    }
}
