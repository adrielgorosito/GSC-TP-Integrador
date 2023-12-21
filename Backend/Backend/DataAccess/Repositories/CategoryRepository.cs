using Backend.DataAccess.Generic;
using Backend.Domain;

namespace Backend.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(LoanDbContext context) : base(context) { }
    }
}
