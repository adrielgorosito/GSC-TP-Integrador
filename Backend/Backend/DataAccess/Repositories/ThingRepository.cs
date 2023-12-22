using Backend.DataAccess.Generic;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Repositories
{
    public class ThingRepository : GenericRepository<Thing>
    {
        public ThingRepository(LoanDbContext context) : base(context) { }

        public override async Task<Thing?> GetOne(int id)
        {
            return await context.Things
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
