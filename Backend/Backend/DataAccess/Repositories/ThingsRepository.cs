using Backend.DataAccess.Generic;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Repositories
{
    public class ThingsRepository : GenericRepository<Thing>
    {
        public ThingsRepository(LoanDbContext context) : base(context) { }

        public override async Task<Thing?> GetOne(int id)
        {
            return await DbSet
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public override async Task<List<Thing>?> GetAll()
        {
            return await DbSet
                .Include(t => t.Category)
                .ToListAsync();
        }
    }
}
