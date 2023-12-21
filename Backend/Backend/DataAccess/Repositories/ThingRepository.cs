using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class ThingRepository : GenericRepository<Thing>
    {
        public ThingRepository(LoanDbContext context) : base(context) { }
    }
}
