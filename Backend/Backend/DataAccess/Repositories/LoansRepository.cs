using Backend.DataAccess.Generic;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Repositories
{
    public class LoansRepository : GenericRepository<Loan>
    {
        public LoansRepository(LoanDbContext context) : base(context) { }

        public override async Task<Loan?> GetOne(int id)
        {
            return await DbSet
                .Include(l => l.Person)
                .Include(l => l.Thing)
                .Include(l => l.Thing.Category)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public override async Task<List<Loan>?> GetAll()
        {
            return await DbSet
                .Include(l => l.Person)
                .Include(l => l.Thing)
                .Include(l => l.Thing.Category)
                .ToListAsync();
        }
    }
}
