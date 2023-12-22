using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class CategoriesRepository : GenericRepository<Category>
    {
        public CategoriesRepository(LoanDbContext context) : base(context) { }
    }
}
