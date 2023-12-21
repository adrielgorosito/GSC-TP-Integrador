using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class LoanRepository : GenericRepository<Loan>
    {
        public LoanRepository(LoanDbContext context) : base(context) { }
    }
}
