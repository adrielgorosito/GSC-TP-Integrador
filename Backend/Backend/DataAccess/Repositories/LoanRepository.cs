using Backend.DataAccess.Generic;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.Repositories
{
    public class LoanRepository : GenericRepository<Loan>
    {
        public LoanRepository(LoanDbContext context) : base(context) { }

        public override async Task<Loan?> GetOne(int id)
        {
            return await context.Loans
                .Include(l => l.Person)
                .Include(l => l.Thing)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
